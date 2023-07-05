using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "CupRice", menuName = "Scriptable Objects/command/Cup Rice")]
    public class CupRice : Command
    {
        public CupRice()
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
                soldier.runAwayProbability += 10;
            }
        }
    }
}