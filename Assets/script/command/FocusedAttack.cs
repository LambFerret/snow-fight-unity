using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "FocusedAttack", menuName = "Scriptable Objects/command/Focused Attack")]
    public class FocusedAttack : Command
    {
        public FocusedAttack() : base(
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
            var min = 999;

            Soldier soldierTarget = null;
            foreach (var soldier in soldiers)
                if (soldier.rangeX * soldier.rangeY < min)
                {
                    min = soldier.rangeX * soldier.rangeY;
                    soldierTarget = soldier;
                }

            if (soldierTarget != null) soldierTarget.speed *= min - 1;
        }
    }
}