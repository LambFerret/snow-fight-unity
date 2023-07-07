using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "TricksOfTrade", menuName = "Scriptable Objects/command/Tricks Of Trade")]
    public class TricksOfTrade : Command
    {
        public TricksOfTrade()
        {
            id = "TricksOfTrade";
            commandName = "Tricks Of Trade";
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