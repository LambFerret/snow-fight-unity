using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "TraffickingInClassifiedInformation",
        menuName = "Scriptable Objects/command/Trafficking In Classified Information")]
    public class TraffickingInClassifiedInformation : Command
    {
        public TraffickingInClassifiedInformation() : base(
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
            // CommandBuff commandBuff = new CommandBuff(name, CommandBuff.Figure.REUSABLE, 0, true, 1, 1);
            // commandBuff.permanently();
            // commandBuff.hasCondition(List.of(Type.REWARD));
        }
    }
}