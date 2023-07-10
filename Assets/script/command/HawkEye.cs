using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "HawkEye", menuName = "Scriptable Objects/command/Hawk Eye")]
    public class HawkEye : Command
    {
        public HawkEye() : base(
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
            foreach (var soldier in soldiers)
            {
                soldier.rangeX += 2;
                soldier.rangeY -= 1;
            }
        }
    }
}