using script.player;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "Sabotage", menuName = "Scriptable Objects/command/Sabotage")]
    public class Sabotage : Command
    {
        public Sabotage()
        {
            id = "Sabotage";
            commandName = "Sabotage";
            type = Type.Betrayal;
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

        public new void Effect(Player p)
        {
            var t = p.currentCost;
            p.currentCost = 0;
            p.snowAmount += t * 100;
        }
    }
}