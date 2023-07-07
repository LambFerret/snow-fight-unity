using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "RewardLeave", menuName = "Scriptable Objects/command/Reward Leave")]
    public class RewardLeave : Command
    {
        public RewardLeave() : base(
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
                var t = (int)(s.speed * 1.5);
                if (t > 100)
                    s.runAwayProbability = 100;
                else
                    s.speed = t;
            }
        }
    }
}