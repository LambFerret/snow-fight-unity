using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "MutualSurveillance", menuName = "Scriptable Objects/command/Mutual Surveillance")]
    public class MutualSurveillance : Command
    {
        public MutualSurveillance()
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

        public override void Effect(List<Command> commands)
        {
        }



        public override void Effect(List<Soldier> soldiers)
        {
            foreach (var s in soldiers)
            {
                s.runAwayProbability -= 10;
                s.speed *= 9 / 10;
            }
        }
    }
}