using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "HotPocket", menuName = "Scriptable Objects/command/Hot Pocket")]
    public class HotPocket : Command
    {
        public HotPocket()
        {
            id = "CupNoodle";
            commandName = "Cup Noodle";
            type = Type.Operation;
            cost = 3;
            target = Target.Soldier;
            rarity = Rarity.Common;
            price = 300;
            affectToUp = 1;
            affectToMiddle = 1;
            affectToDown = 1;
            usedCount = 1;
            targetCount = 1;
        }

        public new void Effect(List<Soldier> soldiers)
        {
            // var list = PhaseScreen.buffList;
            // for (Buff b : list) {
            //     if (b instanceof SoldierEmpowerBuff) b.controlTurn(+1);
            // }
        }
    }
}