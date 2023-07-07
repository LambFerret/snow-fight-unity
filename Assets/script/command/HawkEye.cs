using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "HawkEye", menuName = "Scriptable Objects/command/Hawk Eye")]
    public class HawkEye : Command
    {
        public HawkEye()
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
            foreach (var soldier in soldiers)
            {
                soldier.rangeX += 2;
                soldier.rangeY -= 1;
            }
        }
    }
}