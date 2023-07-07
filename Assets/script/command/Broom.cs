using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "Broom", menuName = "Scriptable Objects/command/Broom")]
    public class Broom : Command
    {
        public Broom()
        {
            id = "Broom";
            commandName = "Broom";
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