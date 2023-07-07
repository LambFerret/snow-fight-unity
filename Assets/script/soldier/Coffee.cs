using System.Collections.Generic;
using UnityEngine;

namespace script.soldier
{
    [CreateAssetMenu(fileName = "Coffee", menuName = "Scriptable Objects/soldier/Coffee")]
    public class Coffee : Soldier
    {
        public Coffee() : base(
            "Coffee",
            2,
            1,
            2,
            10,
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