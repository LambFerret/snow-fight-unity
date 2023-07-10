using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "DividedWeFall", menuName = "Scriptable Objects/command/Divided We Fall")]
    public class DividedWeFall : Command
    {
        public DividedWeFall() : base(
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

        
        public override void Effect(List<Soldier> soldiers, List<Command> commands)
        {
            var minBranch = GetMinBranch(soldiers);
            var minBranchSoldiers = new List<Soldier>();

            var count = 0;
            foreach (var s in soldiers)
                if (s.branch == minBranch)
                {
                    minBranchSoldiers.Add(s);
                    count++;
                }

            foreach (var s in minBranchSoldiers)
            {
                s.speed += count * 2;
                s.runAwayProbability += count;
            }
        }

        private static Soldier.Branch GetMinBranch(List<Soldier> soldiers)
        {
            var branchCount = new Dictionary<Soldier.Branch, int>();
            foreach (var soldier in soldiers)
            {
                var branch = soldier.branch;
                if (branchCount.ContainsKey(branch))
                    branchCount[branch]++;
                else
                    branchCount.Add(branch, 1);
            }

            var minCount = int.MaxValue;
            var minBranch = default(Soldier.Branch);
            foreach (var entry in branchCount)
                if (entry.Value < minCount)
                {
                    minCount = entry.Value;
                    minBranch = entry.Key;
                }

            return minBranch;
        }
    }
}