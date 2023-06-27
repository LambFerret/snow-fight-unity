namespace script.soldier
{
    public class Coffee : Soldier
    {
        public Coffee()
        {
            id = "Coffee";
            rangeX = 2;
            rangeY = 3;
            speed = 2;
            runAwayProbability = 10;
            rank = Rank.Private;
            branch = Branch.Administrative;
            Talent = UniqueTalent;
        }

        private void UniqueTalent()
        {
            speed += 1;
        }
    }
}