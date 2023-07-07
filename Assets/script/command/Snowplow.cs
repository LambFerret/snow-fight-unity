using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "Snowplow", menuName = "Scriptable Objects/command/Snowplow")]
    public class Snowplow : Command
    {
        public Snowplow()
        {
            id = "Snowplow";
            commandName = "Snowplow";
            type = Type.Operation;
            cost = 3;
            target = Target.Soldier;
            rarity = Rarity.Common;
            price = 300;
            affectToUp = 1;
            affectToMiddle = 1;
            affectToDown = 1;
            usedCount = 1;
            targetCount = 1;
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