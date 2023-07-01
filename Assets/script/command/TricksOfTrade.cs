using System;

namespace script.command
{
    public class TricksOfTrade : Command
    {
        public TricksOfTrade()        {
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
            isReusable = true;
            usedCount = 1;
            targetCount = 1;
        }

        public new void Effect()
        {
        }
    }
}