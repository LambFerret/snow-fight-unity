namespace script.soldier
{
    public class Vanilla : Soldier
    {
        public Vanilla()
        {
            id = "Vanilla";
            rangeX = 1;
            rangeY = 2;
            speed = 3;
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