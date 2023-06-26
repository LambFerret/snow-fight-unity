namespace script.soldier
{
    public class Vanilla : Soldier
    {
        private void Awake()
        {
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