using System.Collections.Generic;
using UnityEngine;

namespace script.soldier
{
    [CreateAssetMenu(fileName = "Vanilla", menuName = "Scriptable Objects/soldier/Vanilla")]
    public class Vanilla : Soldier
    {
        public Vanilla() : base(
            "Vanilla",
            2,
            1,
            3,
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