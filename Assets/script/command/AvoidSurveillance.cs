using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "AvoidSurveillance", menuName = "Scriptable Objects/command/Avoid Surveillance")]
    public class AvoidSurveillance : Command
    {
        public AvoidSurveillance()
        {
            id = "AvoidSurveillance";
            commandName = "Avoid Surveillance";
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