using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "Risotto", menuName = "Scriptable Objects/command/Risotto")]
    public class Risotto : Command
    {
        public Risotto() : base(
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
            // TODO RANDOM SEED
            foreach (var s in soldiers)
                s.empowerLevel = Random.Range(0, 2) == 0 ? Soldier.EmpowerLevel.Empowered : Soldier.EmpowerLevel.Weaken;
        }
    }
}