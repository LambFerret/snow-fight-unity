using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "Camouflage", menuName = "Scriptable Objects/command/Camouflage")]
    public class Camouflage : Command
    {
        public Camouflage() : base(
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
            var max = -999;

            Soldier maxTarget = null;
            foreach (var soldier in soldiers)
                if (soldier.speed > max)
                {
                    max = soldier.speed;
                    maxTarget = soldier;
                }

            var min = 999;

            Soldier minTarget = null;
            foreach (var soldier in soldiers)
                if (soldier.speed < min)
                {
                    min = soldier.speed;
                    minTarget = soldier;
                }

            if (maxTarget != null && minTarget != null && !maxTarget.Equals(minTarget))
            {
                maxTarget.speed = min;
                minTarget.speed = max;
            }
        }
    }
}