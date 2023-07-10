using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "MutualSurveillance", menuName = "Scriptable Objects/command/Mutual Surveillance")]
    public class MutualSurveillance : Command
    {
        public MutualSurveillance() : base(
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

        
        public override void Effect(List<Soldier> soldiers, List<Command> commands)
        {
            foreach (var s in soldiers)
            {
                s.runAwayProbability -= 10;
                s.speed *= 9 / 10;
            }
        }
    }
}