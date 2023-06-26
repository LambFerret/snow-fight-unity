namespace script.soldier
{
    public class Coffee : Soldier
    {
        public Coffee()
        {
            name = "Coffee";
            rangeX = 2;
            rangeY = 3;
            speed = 2;
            runAwayProbability = 10;
            rank = Rank.Private;
            branch = Branch.Administrative;
            Talent = UniqueTalent;
        }

        public void UniqueTalent()
        {
            speed += 1;
        }
    }
}