namespace script.player
{
    [System.Serializable]
    public class Item
    {
        public ItemType Type {get;}
        public string ID {get;}

        public enum ItemType {
            Soldier,
            Command,
            Manual,
            Quest,
            Event,
            Buff,
            Map,
        }
    }
}