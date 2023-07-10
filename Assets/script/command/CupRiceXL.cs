using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "CupRiceXL", menuName = "Scriptable Objects/command/Cup Rice XL")]
    public class CupRiceXL : Command
    {
        public CupRiceXL() : base(
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
            Debug.Log("tell me");
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