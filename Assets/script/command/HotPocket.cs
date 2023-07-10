using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "HotPocket", menuName = "Scriptable Objects/command/Hot Pocket")]
    public class HotPocket : Command
    {
        public HotPocket() : base(
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
            // var list = PhaseScreen.buffList;
            // for (Buff b : list) {
            //     if (b instanceof SoldierEmpowerBuff) b.controlTurn(+1);
            // }
        }
    }
}