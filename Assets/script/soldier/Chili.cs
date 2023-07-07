using System.Collections.Generic;
using UnityEngine;

namespace script.soldier
{
    [CreateAssetMenu(fileName = "Chili", menuName = "Scriptable Objects/soldier/Chili")]
    public class Chili : Soldier
    {
        public Chili() : base(
            "Chili",
            2,
            2,
            10,
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