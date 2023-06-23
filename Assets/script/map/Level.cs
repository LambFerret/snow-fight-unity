using System.Collections.Generic;
using soldier;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

namespace map
{
    public abstract class Level : MonoBehaviour
    {
        private int _width;
        private int _height;
        private TileData[,] _tileGrid;
        private int[,] _maxAmount;
        private int[,] _terrain;
        private int _phaseNumber = 0;
        private int _maxPhaseNumber;
        public Tilemap tilemap;
        public GameObject textPrefab;
        public player.Player player;
        public PhaseState currentState;
        public int maxSnowAmount;
        public int minSnowAmount;
        public int maxSoliderCapacity;
        public Region region;

        protected abstract int[,] GetMaxAmountList();
        protected abstract int[,] GetTerrainList();

        private void Start()
        {
            _maxAmount = GetMaxAmountList();
            _terrain = GetTerrainList();
            Check();
            MakeMapData();
            currentState = PhaseState.Pre;
            _maxPhaseNumber = 1 + ((int)region + 2) * 2;
        }

        public void NextPhase()
        {
            switch (currentState)
            {
                case PhaseState.Pre:
                    Debug.Log("Pre to Ready");
                    currentState = PhaseState.Ready;
                    break;
                case PhaseState.Ready:
                    Debug.Log("Ready to action");

                    currentState = PhaseState.Action;
                    break;
                case PhaseState.Action:
                    Debug.Log("action to ready");
                    if (_phaseNumber < _maxPhaseNumber)
                    {
                        currentState = PhaseState.Ready;
                    }
                    else
                    {
                        if (player.SnowAmount >= minSnowAmount)
                        {
                            Debug.Log("win");
                        }
                        else
                        {
                            Debug.Log("lose");
                        }
                    }

                    break;
            }

            _phaseNumber++;
        }


        private void MakeMapData()
        {
            _tileGrid = new TileData[_width, _height];
            int col = 0;
            int row = 0;
            var bound = tilemap.cellBounds;
            for (var x = bound.xMin; x < bound.xMax; x++)
            {
                for (var y = bound.yMax - 1; y >= bound.yMin; y--)
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
                        var info = _tileGrid[row, col].CurrentAmount + "/" + _tileGrid[row, col].MaxAmount
                                   + "\n x,y is " + x + " / " + y
                                   + "\n" + _tileGrid[row, col].Terrain
                                   + "\n" + currentTile.name;
                        var textObj = Instantiate(textPrefab, tilemap.GetCellCenterWorld(tilePos),
                            Quaternion.identity);
                        textObj.GetComponent<Text>().text = info;
                    }

                    row++;
                }

                row = 0;
                col++;
            }
        }

        private void Check()
        {
            if (_maxAmount.GetLength(0) != _terrain.GetLength(0) || _maxAmount.GetLength(1) != _terrain.GetLength(1))
            {
                Debug.LogError("MaxAmountList size is not equal to Width and Height");
                throw new System.Exception();
            }

            _width = _maxAmount.GetLength(0);
            _height = _maxAmount.GetLength(1);
        }

        public enum PhaseState
        {
            Pre,
            Ready,
            Action
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