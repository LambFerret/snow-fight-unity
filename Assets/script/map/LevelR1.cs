namespace map
{
    public class LevelR1 : Level
    {
        public LevelR1()
        {
            region = Region.Rural;
            maxSnowAmount = 500;
            minSnowAmount = 250;
            maxSoliderCapacity = 5;
        }

        protected override int[,] GetMaxAmountList()
        {
            return new[,]
            {
                { 10, 20, 10, 10, 00 },
                { 10, 20, 10, 00, 00 },
                { 30, 20, 10, 00, 00 },
                { 30, 20, 10, 00, 00 },
                { 30, 20, 10, 00, 00 },
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
                { 1, 1, 1, 1, 1 },
            };
        }
    }
}