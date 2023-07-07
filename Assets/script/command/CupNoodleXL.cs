using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "CupNoodleXL", menuName = "Scriptable Objects/command/Cup Noodle XL")]
    public class CupNoodleXL : Command
    {
        public CupNoodleXL()
        {
            id = "CupNoodleXL";
            commandName = "Cup Noodle XL";
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