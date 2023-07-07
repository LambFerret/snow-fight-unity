using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "Snowplow", menuName = "Scriptable Objects/command/Snowplow")]
    public class Snowplow : Command
    {
        public Snowplow() : base(
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
            foreach (var s in soldiers)
            {
                var t = s.rangeY - 1;
                s.rangeY = 1;
                s.rangeX += t;
            }
        }
    }
}