using UnityEngine;

namespace script.soldier
{
    [CreateAssetMenu(fileName = "Choco", menuName = "Scriptable Objects/soldier/Choco")]
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
        }

        public override void Talent()
        {
            speed += 1;
        }
    }
}