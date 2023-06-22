namespace map
{
    public class LevelR1 : Level
    {
        public LevelR1()
        {
            Width = 5;
            Height = 5;
        }

        public override int[,] GetMaxAmountList()
        {
            return new [,]
            {
                { 10, 20, 10, 10, 00 },
                { 10, 20, 10, 00, 00 },
                { 30, 20, 10, 00, 00 },
                { 30, 20, 10, 00, 00 },
                { 30, 20, 10, 00, 00 },
            };
        }
    }
}