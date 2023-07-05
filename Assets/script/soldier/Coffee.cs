using UnityEngine;

namespace script.soldier
{
    [CreateAssetMenu(fileName = "Coffee", menuName = "Scriptable Objects/soldier/Coffee")]
    public class Coffee : Soldier
    {
        public Coffee()
        {
            id = "Coffee";
            rangeX = 2;
            rangeY = 1;
            speed = 2;
            runAwayProbability = 10;
            rank = Rank.Private;
            branch = Branch.Administrative;
                    }

        public override void Talent()
        {
            speed += 1;
        }
    }
}