using System;

namespace script.player
{
    [Serializable]
    public class Item
    {
        public enum ItemType
        {
            Soldier,
            Command,
            Manual,
            Quest,
            Event,
            Buff,
            Map
        }

        public ItemType Type { get; }
        public string ID { get; }
    }
}