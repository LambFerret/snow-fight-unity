using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "Relax", menuName = "Scriptable Objects/command/Relax")]
    public class Relax : Command
    {
        public Relax() : base(
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