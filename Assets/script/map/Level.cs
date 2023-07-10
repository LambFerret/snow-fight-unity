using System;
using System.Collections.Generic;
using script.overlay;
using script.Overlay;
using script.player;
using script.soldier;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace script.map
{
    public abstract class Level : MonoBehaviour
    {
        public enum Region
        {
            Rural,
            Urban,
            Nation
        }


        public enum TalentTiming
        {
            VictimSelected,
            Located,
            WorkBefore,
            WorkAfter
        }

        public Player player;
        public int maxSnowAmount;
        public int minSnowAmount;
        public int maxSoliderCapacity;
        public Region region;
        public Tilemap tilemap;
        public GameObject victoryPanel;
        public GameObject defeatPanel;
        public SoldierOverlay soldierOverlay;
        public CommandOverlay commandOverlay;
        public SnowBarOverlay snowBarOverlay;
        public GameObject levelAsset;
        public GameObject textAsset;
        private int _height;
        private int[,] _maxAmount;
        private int[,] _terrain;
        [SerializeField] private TileData[,] _tileGrid;
        private int _width;

        private GameObject _workingPlace;

        private void Start()
        {
            player = Player.PlayerInstance;
            _workingPlace = GameObject.Find("CanvasOverlay/Place");
            _maxAmount = GetMaxAmountList();
            _terrain = GetTerrainList();
            Check();
            MakeMapData();
            snowBarOverlay.SetMaxSnowAmount(maxSnowAmount);
        }

        protected abstract int[,] GetMaxAmountList();
        protected abstract int[,] GetTerrainList();

        private void MakeMapData()
        {
            _tileGrid = new TileData[_width, _height];
            var col = 0;
            var row = 0;
            var bound = tilemap.cellBounds;
            for (var x = bound.xMin; x < bound.xMax; x++)
            {
                for (var y = bound.yMin; y < bound.yMax; y++)
                {
                    var tilePos = new Vector3Int(x, y, 0);
                    var currentTile = tilemap.GetTile(tilePos);
                    if (currentTile != null)
                    {
                        _tileGrid[row, col] = new TileData
                        {
                            Terrain = (TileData.TerrainType)_terrain[row, col],
                            CurrentAmount = 0,
                            MaxAmount = _maxAmount[row, col],
                            Soldiers = new List<Soldier>()
                        };
                        var parentTransform = _workingPlace.transform.Find("TileLabelPlace").transform;
                        Instantiate(textAsset, tilemap.GetCellCenterWorld(tilePos), Quaternion.identity,
                            parentTransform);
                    }

                    row++;
                }

                row = 0;
                col++;
            }

            LabelingTiles();
        }

        private void Check()
        {
            if (_maxAmount.GetLength(0) != _terrain.GetLength(0) || _maxAmount.GetLength(1) != _terrain.GetLength(1))
            {
                Debug.LogError("MaxAmountList size is not equal to Width and Height");
                throw new Exception();
            }

            _width = _maxAmount.GetLength(0);
            _height = _maxAmount.GetLength(1);
        }

        public void LocateWorkingPlace()
        {
            var cols = _tileGrid.GetLength(0);
            var rows = _tileGrid.GetLength(1);
            var bound = tilemap.cellBounds;
            var startX = bound.xMin;
            var startY = bound.yMin;
            foreach (var s in player.soldiersInThisLevel)
            {
                var i = s.rangeX > cols ? cols : s.rangeX;
                var j = s.rangeY > rows ? rows : s.rangeY;
                var topLeftCol = Random.Range(startX, startX + cols - i);
                var topLeftRow = Random.Range(startY, startY + rows - j);
                CreateImageOverlay(topLeftCol, topLeftRow, i, j, s);
                for (var row = topLeftRow; row < topLeftRow + j; row++)
                for (var col = topLeftCol; col < topLeftCol + i; col++)
                    _tileGrid[row - startX, col - startY].Soldiers.Add(s);
            }

            soldierOverlay.EffectTalent(TalentTiming.Located);
        }

        public void HappyWorking()
        {
            soldierOverlay.EffectTalent(TalentTiming.WorkBefore);
            for (var i = 0; i < _tileGrid.GetLength(0); i++)
            for (var j = 0; j < _tileGrid.GetLength(1); j++)
                foreach (var s in _tileGrid[i, j].Soldiers)
                {
                    var currentAmount = _tileGrid[i, j].CurrentAmount;
                    var maxAmount = _tileGrid[i, j].MaxAmount;
                    if (currentAmount + s.speed > maxAmount)
                        _tileGrid[i, j].CurrentAmount = maxAmount;
                    else
                        _tileGrid[i, j].CurrentAmount += s.speed;

                    if (player.snowAmount + _tileGrid[i, j].CurrentAmount - currentAmount > maxSnowAmount)
                        player.snowAmount = maxSnowAmount;
                    else
                        player.snowAmount += _tileGrid[i, j].CurrentAmount - currentAmount;
                }

            LabelingTiles();
            SetSoldierAnimation(true);
            Debug.Log(player.snowAmount + " / " + maxSnowAmount);
            soldierOverlay.EffectTalent(TalentTiming.WorkAfter);
        }

        private void CreateImageOverlay(int startX, int startY, int width, int height, Soldier soldier)
        {
            var topLeftWorldPos = tilemap.CellToWorld(new Vector3Int(startX, startY, 0));
            var bottomRightWorldPos = tilemap.CellToWorld(new Vector3Int(startX + width, startY + height, 0));
            var centerPos = (topLeftWorldPos + bottomRightWorldPos) / 2;
            var imagePrefab = levelAsset.transform.Find("Cloud").gameObject;
            var soldierStandPrefab = soldierOverlay.prefab.transform.Find("Stand").gameObject;

            var parentTransform = _workingPlace.transform.Find("CloudPlace").transform;
            var standTransform = _workingPlace.transform.Find("StandPlace").transform;

            var cellX = Mathf.Abs(tilemap.cellSize.x);
            var cellY = Mathf.Abs(tilemap.cellSize.y);

            var image = Instantiate(imagePrefab, centerPos, Quaternion.identity, parentTransform);
            var stand = Instantiate(soldierStandPrefab, centerPos, Quaternion.identity, standTransform);

            var soldierImage = soldier.MakeSoldierStanding(stand);
            image.transform.localScale = new Vector3(width * cellX, height * cellY, 1);
            soldierImage.transform.localScale = new Vector3(cellX, cellY, 1);
        }

        public void SetSoldierAnimation(bool isWorking)
        {
            foreach (Transform soldier in _workingPlace.transform.Find("StandPlace").transform)
                soldier.GetComponent<Animator>().SetBool("isWorking", isWorking);
        }

        public void ResetWorkingPlace()
        {
            foreach (Transform child in _workingPlace.transform.Find("CloudPlace").transform) Destroy(child.gameObject);

            foreach (Transform child in _workingPlace.transform.Find("StandPlace").transform) Destroy(child.gameObject);
        }

        private void LabelingTiles()
        {
            var i = 0;
            foreach (Transform child in _workingPlace.transform.Find("TileLabelPlace").transform)
                if (child.gameObject.name.Contains("Text"))
                {
                    var row = i % _width;
                    var col = i / _width;
                    i++;
                    var info = _tileGrid[row, col].CurrentAmount + "/" + _tileGrid[row, col].MaxAmount;
                    child.GetComponent<Text>().text = info;
                }
        }
    }

    public struct TileData
    {
        public TerrainType Terrain;
        public int CurrentAmount;
        public int MaxAmount;
        public List<Soldier> Soldiers;

        public enum TerrainType
        {
            Sea,
            Lake,
            Town,
            Plain,
            Mountain,
            Forest1,
            Forest2,
            Forest3,
            Forest4,
            Forest5,
            Forest6,
            Forest7,
            Forest8,
            Forest9,
            Forest0
        }
    }
}