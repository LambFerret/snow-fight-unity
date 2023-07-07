using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "TraffickingInClassifiedInformation",
        menuName = "Scriptable Objects/command/Trafficking In Classified Information")]
    public class TraffickingInClassifiedInformation : Command
    {
        public TraffickingInClassifiedInformation()
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
            // CommandBuff commandBuff = new CommandBuff(name, CommandBuff.Figure.REUSABLE, 0, true, 1, 1);
            // commandBuff.permanently();
            // commandBuff.hasCondition(List.of(Type.REWARD));
        }
    }
}