using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "RewardLeaveForNoSmoke",
        menuName = "Scriptable Objects/command/Reward Leave For No Smoke")]
    public class RewardLeaveForNoSmoke : Command
    {
        public RewardLeaveForNoSmoke() : base(
            "AvoidSurveillance",
            Type.Operation,
            3,
            Target.Soldier,
            Rarity.Common,
            300,
            1,
            1,
            1,
            1,
            1
        )
        {
        }

        public override void Effect(List<Command> commands)
        {
        }


        public override void Effect(List<Soldier> soldiers)
        {
            foreach (var s in soldiers)
            {
                var t = s.speed - 30;
                s.runAwayProbability = t <= 0 ? 100 : t;
            }
        }
    }
}