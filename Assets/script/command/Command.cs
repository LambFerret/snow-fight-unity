using System;
using UnityEngine;
using UnityEngine.UI;

namespace script.command
{
    [Serializable]
    public class Command
    {
        public string id;
        public string commandName;
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

        public delegate void EffectCommand();

        public EffectCommand Effect;

        public GameObject MakeCommandPrefab(GameObject prefab)
        {
            var nameText = prefab.transform.Find("Card/Paper/commandName").GetComponent<Text>();
            var effectDescriptionText = prefab.transform.Find("Card/Paper/effectDescription").GetComponent<Text>();
            // var commandIcon = prefab.transform.Find("Card/Front/Icon").GetComponent<Image>();
            var costText = prefab.transform.Find("Card/Front/Cost/cost").GetComponent<Text>();
            var typeText = prefab.transform.Find("Card/Back/type").GetComponent<Text>();

            nameText.text = commandName;
            effectDescriptionText.text = "effectDescription";
            costText.text = cost.ToString();
            typeText.text = type.ToString();

            return prefab;
        }

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