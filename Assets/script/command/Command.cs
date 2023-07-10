using System;
using System.Collections.Generic;
using script.manager;
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
            SoldierAll,
            Soldier,
            SoldierSelected,
            CommandDeck,
            CommandThisTurn,
            CommandSelected,
            Player,
            UI,
            Level
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
        public int affectMultiplier;

        protected int initialCost;

        protected BuffManager BuffManager => BuffManager.BuffManagerInstance;

        protected Command(
            string id,
            Type type,
            int cost,
            Target target,
            Rarity rarity,
            int price,
            int affectToUp,
            int affectToMiddle,
            int affectToDown,
            int usedCount,
            int targetCount
        )
        {
            this.id = id;
            commandName = id;
            this.type = type;
            this.cost = cost;
            this.target = target;
            this.rarity = rarity;
            this.price = price;
            this.affectToUp = affectToUp;
            this.affectToMiddle = affectToMiddle;
            this.affectToDown = affectToDown;
            this.usedCount = usedCount;
            this.targetCount = targetCount;
            initialCost = cost;
        }

        public void ResetValues()
        {
            cost = initialCost;
            affectMultiplier = 1;
        }

        public void Effect()
        {
            var player = Player.PlayerInstance;
            switch (target)
            {
                case Target.Soldier:
                    Effect(player.soldiersInThisLevel, null);
                    break;
                case Target.SoldierSelected:
                    Debug.Log("selected player effect TODO");
                    break;
                case Target.SoldierAll:
                    Effect(player.soldiers, null);
                    break;
                case Target.CommandSelected:
                    // Effect(player.);
                    break;
                case Target.CommandDeck:
                    Effect(null, player.commands);
                    break;
                case Target.CommandThisTurn:
                    Effect(null, player.hand);
                    break;
                case Target.Player:
                    Effect(null, null);
                    break;
                case Target.UI:
                    // Effect(player.UI);
                    break;
                case Target.Level:
                    // Effect();
                    break;
            }
        }

        public abstract void Effect(List<Soldier> soldiers, List<Command> commands);

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