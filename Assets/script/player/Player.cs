using System;
using System.Collections.Generic;
using script.command;
using script.soldier;
using UnityEngine;

namespace script.player
{
    [Serializable]
    [CreateAssetMenu(fileName = "Player", menuName = "Scriptable Objects/Player/player", order = 1)]
    public class Player : ScriptableObject
    {
        public enum Affinity
        {
            Upper,
            Middle,
            Down
        }

        private static Player _instance;

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
        public List<Command> totalDeck;
        public List<Command> usedCommandList;
        public List<Command> removalFromGameCommandList;
        public List<Command> hand;
        // private List<Item> shopItems;
        private Player()
        {
            SemiConstructor();
        }

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

        private void SemiConstructor()
        {
            snowAmount = 0;
            day = 0;
            money = 1000;
            maxCost = 15;
            currentCost = maxCost;
            snowAmount = 0;
            difficulty = 0;
            clearedMainQuestNumber = 0;
            downAffinity = 10;
            middleAffinity = 50;
            upperAffinity = 10;
            maxManualCapacity = 3;
            maxCommandInHand = 5;
        }

        public void Init(List<Soldier> soldierList, List<Command> commandList)
        {
            Debug.Log("game manager inits the player");
            soldiers = soldierList;
            commands = commandList;
            SemiConstructor();
        }
    }
}