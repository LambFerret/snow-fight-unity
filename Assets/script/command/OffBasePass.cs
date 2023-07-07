using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "OffBasePass", menuName = "Scriptable Objects/command/Off Base Pass")]
    public class OffBasePass : Command
    {
        public OffBasePass()
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
            foreach (var soldier in soldiers)
                switch (soldier.empowerLevel)
                {
                    case Soldier.EmpowerLevel.Weaken:
                        soldier.empowerLevel = Soldier.EmpowerLevel.Neutral;
                        break;
                    case Soldier.EmpowerLevel.Neutral:
                        soldier.empowerLevel = Soldier.EmpowerLevel.Empowered;
                        break;
                    case Soldier.EmpowerLevel.Empowered:
                        soldier.runAwayProbability = 100;
                        break;
                }
        }
    }
}