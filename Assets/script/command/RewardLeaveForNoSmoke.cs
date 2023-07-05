using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "RewardLeaveForNoSmoke", menuName = "Scriptable Objects/command/Reward Leave For No Smoke")]
    public class RewardLeaveForNoSmoke : Command
    {

        public RewardLeaveForNoSmoke()
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
            foreach (var s in soldiers)
            {
                var t = s.speed - 30;
                s.runAwayProbability = t <= 0 ? 100 : t;
            }
        }
    }
}