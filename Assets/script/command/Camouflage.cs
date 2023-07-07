using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "Camouflage", menuName = "Scriptable Objects/command/Camouflage")]
    public class Camouflage : Command
    {
        public Camouflage()
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

        public override void Effect(List<Command> commands)
        {
        }



        public override void Effect(List<Soldier> soldiers)
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