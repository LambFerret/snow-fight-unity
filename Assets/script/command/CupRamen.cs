using System.Collections.Generic;
using script.player;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "CupRamen", menuName = "Scriptable Objects/command/Cup Ramen")]
    public class CupRamen : Command
    {
        public CupRamen()
        {
            id = "CupRamen";
            commandName = "Cup Ramen";
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
            Debug.Log("tell me ramen");
        }
    }
}