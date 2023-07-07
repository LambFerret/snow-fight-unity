using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "Relax", menuName = "Scriptable Objects/command/Relax")]
    public class Relax : Command
    {
        public Relax()
        {
            id = "Relax";
            commandName = "Relax";
            type = Type.Reward;
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

            Soldier targetSoldier = null;
            foreach (var soldier in soldiers)
                if (soldier.rangeX * soldier.rangeY > max)
                {
                    max = soldier.rangeX * soldier.rangeY;
                    targetSoldier = soldier;
                }

            if (targetSoldier != null) targetSoldier.speed *= targetSoldier.rangeY;
        }
    }
}