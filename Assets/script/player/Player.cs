using System;
using System.Collections.Generic;
using script.command;
using script.soldier;
using UnityEngine;

namespace script.player
{
    [Serializable]
    [CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player", order = 1)]
    public class Player : ScriptableObject
    {
        // public ItemLibrary library = GameManager.Instance.itemLibrary;
        // private List<Manual> manuals;
        // private List<Quest> quests;
        public List<Soldier> soldiers;
        public List<Command> commands;
        public int clearedMainQuestNumber;
        public int day;
        public int money;
        public int maxCost;
        public int difficulty;
        public int currentCost;
        public int snowAmount;
        public int middleAffinity;
        public int downAffinity;
        public int upperAffinity;
        public int maxManualCapacity;
        public int maxCommandInHand;

        private static Player _instance;

        public static Player PlayerInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<Player>("Player");
                    if (!_instance) Debug.LogError("Player not found");
                }

                return _instance;
            }
        }

        // private List<Item> shopItems;
        private Player()
        {
            day = 0;
            money = 1000;
            maxCost = 15;
            currentCost = maxCost;
            difficulty = 0;
            clearedMainQuestNumber = 0;
            downAffinity = 10;
            middleAffinity = 50;
            upperAffinity = 10;
            maxManualCapacity = 3;
            maxCommandInHand = 5;
        }

        public void Init(List<Soldier> soldiers, List<Command> commands)
        {
            Debug.Log("game manager inits the player");

            this.soldiers = soldiers;
            this.commands = commands;
            Debug.Log("player has " + this.soldiers.Count + " soldiers");
        }

        public enum Affinity
        {
            Upper,
            Middle,
            Down
        }
    }
}