using UnityEngine;

namespace script.soldier
{
    [CreateAssetMenu(fileName = "Chili", menuName = "Scriptable Objects/soldier/Chili")]
    public class Chili : Soldier
    {
        public Chili()
        {
            id = "Chili";
            rangeX = 2;
            rangeY = 2;
            speed = 10;
            runAwayProbability = 30;
            rank = Rank.Private;
            branch = Branch.Administrative;
        }

        public override void Talent()
        {
            speed += 1;
        }
    }
}