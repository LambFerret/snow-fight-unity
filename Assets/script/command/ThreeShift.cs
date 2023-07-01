using UnityEngine;

namespace script.command
{
    public class ThreeShift : Command
    {
        public ThreeShift()
        {
            id = "ThreeShift";
            commandName = "Three Shift";
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
            Debug.Log("ThreeShift");
        }
    }
}