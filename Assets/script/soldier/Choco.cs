using System.Collections.Generic;
using UnityEngine;

namespace script.soldier
{
    [CreateAssetMenu(fileName = "Choco", menuName = "Scriptable Objects/soldier/Choco")]
    public class Choco : Soldier
    {
        public Choco() : base(
            "Choco",
            1,
            1,
            5,
            30,
            new List<Terrain>(),
            Rank.Private,
            Branch.Administrative
        )
        {
        }

        public override void Talent()
        {
            speed += 1;
        }
    }
}