using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "Risotto", menuName = "Scriptable Objects/command/Risotto")]
    public class Risotto : Command
    {
        public Risotto()
        {
            id = "Risotto";
            commandName = "Risotto";
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
            // TODO RANDOM SEED
            foreach (var s in soldiers)
                s.empowerLevel = Random.Range(0, 2) == 0 ? Soldier.EmpowerLevel.Empowered : Soldier.EmpowerLevel.Weaken;
        }
    }
}