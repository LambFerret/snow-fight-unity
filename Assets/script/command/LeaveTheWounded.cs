using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "LeaveTheWounded", menuName = "Scriptable Objects/command/Leave The Wounded")]
    public class LeaveTheWounded : Command
    {
        public LeaveTheWounded()
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
            foreach (var soldier in soldiers)
                switch (soldier.empowerLevel)
                {
                    case Soldier.EmpowerLevel.Weaken:
                        soldier.rangeX = 1;
                        soldier.rangeY = 1;
                        break;
                    case Soldier.EmpowerLevel.Neutral:

                        break;

                    case Soldier.EmpowerLevel.Empowered:
                        soldier.runAwayProbability *= 4 / 10;
                        break;
                }
        }
    }
}