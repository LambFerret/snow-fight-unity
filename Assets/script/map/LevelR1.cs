namespace script.map
{
    public class LevelR1 : Level
    {
        public LevelR1()
        {
            region = Region.Rural;
            maxSnowAmount = 500;
            minSnowAmount = 250;
            maxSoliderCapacity = 2;
        }

        protected override int[,] GetMaxAmountList()
        {
            return new[,]
            {
                { 10, 20, 30, 10, 60 },
                { 10, 20, 30, 40, 60 },
                { 30, 20, 30, 40, 60 },
                { 30, 20, 10, 40, 60 },
                { 30, 20, 10, 40, 60 }
            };
        }

        protected override int[,] GetTerrainList()
        {
            return new[,]
            {
                { 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1 }
            };
        }
    }
}