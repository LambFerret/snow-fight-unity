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

namespace map
{
    public abstract class Level : MonoBehaviour
    {
        private int _width;
        private int _height;
        [SerializeField] private TileData[,] _tileGrid;
        private int[,] _maxAmount;
        private int[,] _terrain;
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

        private GameObject _workingPlace;

        protected abstract int[,] GetMaxAmountList();
        protected abstract int[,] GetTerrainList();

        private void Start()
        {
            _workingPlace = GameObject.Find("CanvasOverlay/Place");
            _maxAmount = GetMaxAmountList();
            _terrain = GetTerrainList();
            Check();
            MakeMapData();
            snowBarOverlay.SetMaxSnowAmount(maxSnowAmount);
        }

        private void MakeMapData()
        {
            _tileGrid = new TileData[_width, _height];
            int col = 0;
            int row = 0;
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
            int cols = _tileGrid.GetLength(0);
            int rows = _tileGrid.GetLength(1);
            var bound = tilemap.cellBounds;
            int startX = bound.xMin;
            int startY = bound.yMin;
            foreach (var s in soldierOverlay.soldiers)
            {
                int i = s.rangeX > cols ? cols : s.rangeX;
                int j = s.rangeY > rows ? rows : s.rangeY;
                int topLeftCol = Random.Range(startX, startX + cols - i);
                int topLeftRow = Random.Range(startY, startY + rows - j);
                CreateImageOverlay(topLeftCol, topLeftRow, i, j, s);
                for (int row = topLeftRow; row < topLeftRow + j; row++)
                {
                    for (int col = topLeftCol; col < topLeftCol + i; col++)
                    {
                        _tileGrid[row - startX, col - startY].Soldiers.Add(s);
                    }
                }
            }

            soldierOverlay.EffectTalent(TalentTiming.Located);
        }

        public void HappyWorking()
        {
            Player player = Player.PlayerInstance;
            soldierOverlay.EffectTalent(TalentTiming.WorkBefore);
            for (int i = 0; i < _tileGrid.GetLength(0); i++)
            {
                for (int j = 0; j < _tileGrid.GetLength(1); j++)
                {
                    foreach (var s in _tileGrid[i, j].Soldiers)
                    {
                        int currentAmount = _tileGrid[i, j].CurrentAmount;
                        int maxAmount = _tileGrid[i, j].MaxAmount;
                        if (currentAmount + s.speed > maxAmount)
                        {
                            _tileGrid[i, j].CurrentAmount = maxAmount;
                        }
                        else
                        {
                            _tileGrid[i, j].CurrentAmount += s.speed;
                        }

                        if (player.snowAmount + _tileGrid[i, j].CurrentAmount - currentAmount > maxSnowAmount)
                        {
                            player.snowAmount = maxSnowAmount;
                        }
                        else
                        {
                            player.snowAmount += _tileGrid[i, j].CurrentAmount - currentAmount;
                        }
                    }
                }
            }

            LabelingTiles();
            Debug.Log(player.snowAmount + " / " + maxSnowAmount);
            soldierOverlay.EffectTalent(TalentTiming.WorkAfter);
        }

        private void CreateImageOverlay(int startX, int startY, int width, int height, Soldier soldier)
        {
            Debug.Log("xywh : " + startX + " " + startY + " " + width + " " + height);
            Vector3 topLeftWorldPos = tilemap.CellToWorld(new Vector3Int(startX, startY, 0));
            Vector3 bottomRightWorldPos = tilemap.CellToWorld(new Vector3Int(startX + width, startY + height, 0));
            Vector3 centerPos = (topLeftWorldPos + bottomRightWorldPos) / 2;
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

        public void ResetWorkingPlace()
        {
            foreach (Transform child in _workingPlace.transform.Find("CloudPlace").transform)
            {
                Destroy(child.gameObject);
            }

            foreach (Transform child in _workingPlace.transform.Find("StandPlace").transform)
            {
                Destroy(child.gameObject);
            }
        }

        private void LabelingTiles()
        {
            int i = 0;
            foreach (Transform child in _workingPlace.transform.Find("TileLabelPlace").transform)
            {
                if (child.gameObject.name.Contains("Text"))
                {
                    int row = i % _width;
                    int col = i / _width;
                    i++;
                    var info = _tileGrid[row, col].CurrentAmount + "/" + _tileGrid[row, col].MaxAmount;
                    child.GetComponent<Text>().text = info;
                }
            }
        }


        public enum TalentTiming
        {
            VictimSelected,
            Located,
            WorkBefore,
            WorkAfter
        }

        public enum Region
        {
            Rural,
            Urban,
            Nation
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
            Forest0,
        }
    }
}