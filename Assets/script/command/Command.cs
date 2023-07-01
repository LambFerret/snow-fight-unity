using System;
using UnityEngine;
using UnityEngine.UI;

namespace script.command
{
    [Serializable]
    public class Command : IEffectBehavior
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

        public void Effect()
        {

        }

        public GameObject MakeCommandCard(GameObject prefab)
        {
            GameObject card = prefab.transform.Find("Card").gameObject;

            var nameText = card.transform.Find("Paper/commandName").GetComponent<Text>();
            var effectDescriptionText = card.transform.Find("Paper/effectDescription").GetComponent<Text>();
            // var commandIcon = card.transform.Find("Card/Front/Icon").GetComponent<Image>();
            var costText = card.transform.Find("Front/Cost/cost").GetComponent<Text>();
            var typeText = card.transform.Find("Back/LabelText").GetComponent<Text>();

            nameText.text = commandName;
            effectDescriptionText.text = "effectDescription";
            costText.text = cost.ToString();
            typeText.text = type.ToString();

            return card;
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