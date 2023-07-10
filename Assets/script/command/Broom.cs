using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "Broom", menuName = "Scriptable Objects/command/Broom")]
    public class Broom : Command
    {
        public Broom() : base(
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
        }
    }
}