using System.Collections.Generic;
using soldier;

namespace player
{
    [System.Serializable]
    public class Player
    {
        // private readonly Set<PlayerObserver> listeners;
        // private Map<Affinity, Integer> affinity;
        private List<Soldier> soldiers;
        // private List<Command> commands;
        // private List<Manual> manuals;
        // private List<Quest> quests;
        public string PlayerName { get; private set; }
        public int ClearedMainQuestNumber { get; private set; }
        public int Day { get; private set; }
        public int Money { get; private set; }
        public int MaxCost { get; private set; }
        public int CurrentCost { get; private set; }
        public int Difficulty { get; private set; }
        public int SnowAmount { get; private set; }
        public int MiddleAffinity { get; private set; }
        public int DownAffinity { get; private set; }
        public int UpperAffinity { get; private set; }
        public int MaxManualCapacity { get; private set; }
        public int MaxCommandInHand { get; private set; }

        // private List<Item> shopItems;
        public Player()
        {
            Day = 0;
            Money = 1000;
            MaxCost = 15;
            CurrentCost = MaxCost;
            Difficulty = 0;
            ClearedMainQuestNumber = 0;
            DownAffinity = 10;
            MiddleAffinity = 50;
            UpperAffinity = 10;
            MaxManualCapacity = 3;
            MaxCommandInHand = 5;
        }

        public enum Affinity
        {
            Upper,
            Middle,
            Down
        }
    }
}