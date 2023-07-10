using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "CupRice", menuName = "Scriptable Objects/command/Cup Rice")]
    public class CupRice : Command
    {
        public CupRice() : base(
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
            {
                soldier.empowerLevel = Soldier.EmpowerLevel.Empowered;
                soldier.runAwayProbability += 10;
            }
        }
    }
}