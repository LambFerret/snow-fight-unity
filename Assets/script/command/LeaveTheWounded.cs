using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "LeaveTheWounded", menuName = "Scriptable Objects/command/Leave The Wounded")]
    public class LeaveTheWounded : Command
    {
        public LeaveTheWounded() : base(
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