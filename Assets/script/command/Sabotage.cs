using System.Collections.Generic;
using script.player;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "Sabotage", menuName = "Scriptable Objects/command/Sabotage")]
    public class Sabotage : Command
    {
        public Sabotage() : base(
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

        public override void Effect(List<Soldier> soldiers)
        {
        }

        public override void Effect(List<Command> commands)
        {
            var p = Player.PlayerInstance;
            var t = p.currentCost;
            p.currentCost = 0;
            p.snowAmount += t * 100;
        }
    }
}