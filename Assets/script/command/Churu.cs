using System.Collections.Generic;
using script.player;
using script.soldier;
using UnityEngine;
using Random = System.Random;

namespace script.command
{
    [CreateAssetMenu(fileName = "Churu", menuName = "Scriptable Objects/command/Churu")]
    public class Churu : Command
    {
        public Churu() : base(
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
            var count = DeleteDuplicated();

            if (count > soldiers.Count)
            {
                foreach (var s in soldiers) s.empowerLevel = Soldier.EmpowerLevel.Empowered;
                return;
            }

            var temp = new List<Soldier>(soldiers);
            Shuffle(temp);
            foreach (var s in temp.GetRange(0, count)) s.empowerLevel = Soldier.EmpowerLevel.Empowered;
        }

        private static void Shuffle<T>(IList<T> list)
        {
            var random = new Random();
            for (var i = 0; i < list.Count - 1; i++)
            {
                var r = random.Next(i, list.Count);
                (list[i], list[r]) = (list[r], list[i]);
            }
        }

        private static int DeleteDuplicated()
        {
            var player = Player.PlayerInstance;
            var commandList = new List<List<Command>> { player.hand, player.totalDeck, player.usedCommandList };
            var count = 0;

            foreach (var list in commandList)
                for (var i = list.Count - 1; i >= 0; i--)
                    if (list[i] is Churu)
                    {
                        count++;
                        player.removalFromGameCommandList.Add(list[i]);
                        list.RemoveAt(i);
                    }

            return count;
        }
    }
}