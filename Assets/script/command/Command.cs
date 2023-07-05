using System;
using System.Collections.Generic;
using map;
using script.player;
using script.soldier;
using UnityEngine;
using UnityEngine.UI;

namespace script.command
{
    [Serializable]
    public abstract class Command : ScriptableObject
    {

        public enum Rarity
        {
            Common,
            Uncommon,
            Rare,
            Epic,
            Legendary
        }

        public enum Target
        {
            Player,
            Soldier,
            UI,
            Level,
            Command
        }

        public enum Type
        {
            Operation,
            Reward,
            Betrayal
        }

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
        public int usedCount;
        public int targetCount;

        public void Effect(List<Soldier> soldiers, List<Command> commands, Level level)
        {
            switch (target)
            {
                case Target.Player:
                    Effect(Player.PlayerInstance);
                    break;
                case Target.Soldier:
                    Effect(soldiers);
                    break;
                case Target.Command:
                    Effect(commands);
                    break;
                case Target.Level:
                    Effect(level);
                    break;
                case Target.UI:

                    break;
            }
        }

        public void Effect(List<Command> commands)
        {
        }

        public void Effect(List<Soldier> soldiers)
        {
        }

        public void Effect(Level level)
        {
        }

        public void Effect(Player player)
        {
        }

        public GameObject MakeCommandCard(GameObject prefab)
        {
            var card = prefab.transform.Find("Card").gameObject;

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
    }
}