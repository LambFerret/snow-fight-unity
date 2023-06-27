namespace script.soldier
{
    public class Choco : Soldier
    {
        public Choco()
        {
            id = "Choco";
            rangeX = 2;
            rangeY = 6;
            speed = 5;
            runAwayProbability = 30;
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