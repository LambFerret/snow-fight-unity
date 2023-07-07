using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "SupplyEmbezzlement", menuName = "Scriptable Objects/command/Supply Embezzlement")]
    public class SupplyEmbezzlement : Command
    {
        public SupplyEmbezzlement() : base(
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
            // CommandBuff buff = new CommandBuff(name, CommandBuff.Figure.COST, 0, true, 1, 1);
            // buff.permanently();
            // buff.hasCondition(List.of(Type.OPERATION));
            // PhaseScreen.addBuff(buff);
        }
    }
}