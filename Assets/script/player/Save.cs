using System.Collections.Generic;

namespace script.player
{
    public class Save
    {
        public long Time;
        public List<Item> AllItems;
        public int Day;
        public int Money;
        public Dictionary<Player.Affinity, int> Affinity;
        public int MaxCost;
        public int MaxManualCapacity;
        public int MaxCommandInHand;
        public List<string> EventList;
        public List<Item> ShopList;
    }
}