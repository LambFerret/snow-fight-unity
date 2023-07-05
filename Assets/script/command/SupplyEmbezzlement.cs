using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "SupplyEmbezzlement", menuName = "Scriptable Objects/command/Supply Embezzlement")]
    public class SupplyEmbezzlement : Command
    {
        public SupplyEmbezzlement()
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
            // CommandBuff buff = new CommandBuff(name, CommandBuff.Figure.COST, 0, true, 1, 1);
            // buff.permanently();
            // buff.hasCondition(List.of(Type.OPERATION));
            // PhaseScreen.addBuff(buff);
        }
    }
}