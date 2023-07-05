using UnityEngine;

namespace script.soldier
{
    [CreateAssetMenu(fileName = "Vanilla", menuName = "Scriptable Objects/soldier/Vanilla")]
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
                    }

        public override void Talent()
        {
            speed += 1;
        }
    }
}