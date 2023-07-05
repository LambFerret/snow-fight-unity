using System.Collections.Generic;

namespace script.player
{
    public class Save
    {
        public Dictionary<Player.Affinity, int> Affinity;
        public List<Item> AllItems;
        public int Day;
        public List<string> EventList;
        public int MaxCommandInHand;
        public int MaxCost;
        public int MaxManualCapacity;
        public int Money;
        public List<Item> ShopList;
        public long Time;
    }
}