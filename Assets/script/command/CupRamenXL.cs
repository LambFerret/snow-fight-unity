using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "CupRamenXL", menuName = "Scriptable Objects/command/Cup Ramen XL")]
    public class CupRamenXL : Command
    {
        public CupRamenXL() : base(
            "AvoidSurveillance",
            Type.Operation,
            3,
            Target.Soldier,
            Rarity.Common,
            300,
            1,
            1,
            1,
            1,
            1
        )
        {
        }

        public override void Effect(List<Soldier> soldiers, List<Command> commands)
        {
        }
    }
}