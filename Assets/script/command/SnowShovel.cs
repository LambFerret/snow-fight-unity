using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "SnowShovel", menuName = "Scriptable Objects/command/Snow Shovel")]
    public class SnowShovel : Command
    {
        public SnowShovel()
        {
            id = "SnowShovel";
            commandName = "Snow Shovel";
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
        }
    }
}