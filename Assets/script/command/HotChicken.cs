using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "HotChicken", menuName = "Scriptable Objects/command/Hot Chicken")]
    public class HotChicken : Command
    {
        public HotChicken()
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
            // SoldierEmpowerBuff buff = new SoldierEmpowerBuff(name, soldiers, EmpowerLevel.NEUTRAL, 1);
            // buff.permanently();
            // buff.hasCondition(EmpowerLevel.WEAKEN);
            // PhaseScreen.addBuff(buff);
        }
    }
}