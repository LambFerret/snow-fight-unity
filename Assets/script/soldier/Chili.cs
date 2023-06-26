namespace script.soldier
{
    public class Chili : Soldier
    {
        public Chili()
        {
            name = "Chili";
            rangeX = 2;
            rangeY = 1;
            speed = 10;
            runAwayProbability = 30;
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