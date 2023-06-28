namespace script.soldier
{
    public class Choco : Soldier
    {
        public Choco()
        {
            id = "Choco";
            rangeX = 1;
            rangeY = 1;
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