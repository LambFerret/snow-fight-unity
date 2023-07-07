using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "CupRamenXL", menuName = "Scriptable Objects/command/Cup Ramen XL")]
    public class CupRamenXL : Command
    {
        public CupRamenXL()
        {
            id = "CupRamenXL";
            commandName = "Cup Ramen XL";
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

        public override void Effect(List<Command> commands)
        {
        }

        public override void Effect(List<Soldier> soldiers)
        {
        }
    }
}