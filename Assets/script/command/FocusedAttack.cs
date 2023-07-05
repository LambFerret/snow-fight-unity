using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "FocusedAttack", menuName = "Scriptable Objects/command/Focused Attack")]
    public class FocusedAttack : Command
    {
        public FocusedAttack()
        {
            id = "CupNoodle";
            commandName = "Cup Noodle";
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

        public new void Effect(List<Soldier> soldiers)
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