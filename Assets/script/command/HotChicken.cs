using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "HotChicken", menuName = "Scriptable Objects/command/Hot Chicken")]
    public class HotChicken : Command
    {
        public HotChicken() : base(
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
            // SoldierEmpowerBuff buff = new SoldierEmpowerBuff(name, soldiers, EmpowerLevel.NEUTRAL, 1);
            // buff.permanently();
            // buff.hasCondition(EmpowerLevel.WEAKEN);
            // PhaseScreen.addBuff(buff);
        }
    }
}