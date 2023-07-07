using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "CupNoodle", menuName = "Scriptable Objects/command/Cup Noodle")]
    public class CupNoodle : Command
    {
        public int cupNoodleSpeedValue = 3;

        public CupNoodle() : base(
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

        public override void Effect(List<Command> commands)
        {
        }


        public override void Effect(List<Soldier> soldiers)
        {
            foreach (var s in soldiers) s.speed += cupNoodleSpeedValue;
        }
    }
}