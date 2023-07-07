using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.command
{
    [CreateAssetMenu(fileName = "UnitedWeStand", menuName = "Scriptable Objects/command/United We Stand")]
    public class UnitedWeStand : Command
    {
        public UnitedWeStand()
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
            var mostBranch = GetBranchCount(soldiers);
            var mostBranchSoldiers = new List<Soldier>();

            var count = 0;
            foreach (var s in soldiers)
                if (s.branch == mostBranch)
                {
                    mostBranchSoldiers.Add(s);
                    count++;
                }

            foreach (var s in mostBranchSoldiers)
            {
                s.speed += count;
                s.runAwayProbability += 2 * count;
            }
        }

        private static Soldier.Branch GetBranchCount(List<Soldier> soldiers)
        {
            var branchCount = new Dictionary<Soldier.Branch, int>();

            foreach (var soldier in soldiers)
            {
                var branch = soldier.branch;

                if (branchCount.ContainsKey(branch))
                    branchCount[branch]++;
                else
                    branchCount[branch] = 1;
            }

            var maxCount = 0;
            var maxBranch = default(Soldier.Branch);

            foreach (var entry in branchCount)
                if (entry.Value > maxCount)
                {
                    maxCount = entry.Value;
                    maxBranch = entry.Key;
                }

            return maxBranch;
        }
    }
}