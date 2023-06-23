using UnityEngine;

namespace script.command
{
    public abstract class Command : MonoBehaviour
    {
        public Type type;
        public int cost;
        public Target target;
        public Rarity rarity;
        public int price;
        public int affectToUp;
        public int affectToMiddle;
        public int affectToDown;
        public bool isReusable;
        public int usedCount;
        public int targetCount;

        public abstract void Execute();

        public enum Target
        {
            Player,
            Soldier,
            UI,
            Enemy
        }

        public enum Type
        {
            Operation,
            Reward,
            Betrayal,
        }

        public enum Rarity
        {
            Common,
            Uncommon,
            Rare,
            Epic,
            Legendary
        }
    }
}