using System.Collections.Generic;
using script.soldier;
using UnityEngine;
using Random = System.Random;

namespace script.command
{
    [CreateAssetMenu(fileName = "Churu", menuName = "Scriptable Objects/command/Churu")]
    public class Churu : Command
    {
        public Churu()
        {
            id = "Churu";
            commandName = "Churu";
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

        public void Effect(List<Command> deck, List<Soldier> soldiers)
        {
            var count = 0;

            for (var i = deck.Count - 1; i >= 0; i--)
                if (deck[i] is Churu)
                {
                    count++;
                    deck.RemoveAt(i);
                }

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
    }
}