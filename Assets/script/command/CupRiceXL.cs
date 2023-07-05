using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "CupRiceXL", menuName = "Scriptable Objects/command/Cup Rice XL")]
    public class CupRiceXL : Command
    {
        public CupRiceXL()
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
            {
                soldier.empowerLevel = Soldier.EmpowerLevel.Empowered;
                if (soldier.runAwayProbability <= 50)
                    soldier.runAwayProbability = 50;
                else
                    soldier.runAwayProbability += 10;
            }
        }
    }
}