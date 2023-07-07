using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "CupRamen", menuName = "Scriptable Objects/command/Cup Ramen")]
    public class CupRamen : Command
    {
        public CupRamen() : base(
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
            Debug.Log("tell me ramen");
        }
    }
}