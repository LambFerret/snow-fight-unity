using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "AvoidSurveillance", menuName = "Scriptable Objects/command/Avoid Surveillance")]
    public class AvoidSurveillance : Command
    {
        public AvoidSurveillance() : base(
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
        }
    }
}