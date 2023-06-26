namespace script.soldier
{
    public class Vanilla : Soldier
    {
        public Vanilla()
        {
            name = "Vanilla";
            rangeX = 3;
            rangeY = 4;
            speed = 3;
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