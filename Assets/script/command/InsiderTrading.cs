using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "InsiderTrading", menuName = "Scriptable Objects/command/Insider Trading")]
    public class InsiderTrading : Command
    {
        public InsiderTrading() : base(
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

        public override void Effect(List<Command> commands)
        {
        }


        public override void Effect(List<Soldier> soldiers)
        {
            // 클리어시 돈 2배
        }
    }
}