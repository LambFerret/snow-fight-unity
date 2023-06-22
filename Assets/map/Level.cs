using System.Collections.Generic;
using soldier;
using UnityEngine;

namespace map
{
    public abstract class Level : MonoBehaviour
    {
        protected int Width;
        protected int Height;
        private TileData[,] _tileGrid;
        private int[,] _maxAmountList;

        public abstract int[,] GetMaxAmountList();

        private void Start()
        {
            _maxAmountList = GetMaxAmountList();
            // Initialize tileGrid with the correct size
            _tileGrid = new TileData[Width, Height];
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    _tileGrid[i, j] = new TileData()
                    {
                        Terrain = TileData.TerrainType.Sea,
                        CurrentAmount = 0,
                        MaxAmount = _maxAmountList[i, j],
                        Soldiers = new List<Soldier>()
                    };
                }
            }
        }

        public TileData GetTileAt(int x, int y)
        {
            return _tileGrid[x, y];
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