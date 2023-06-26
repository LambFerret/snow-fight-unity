using System;
using System.Collections.Generic;
using script.command;
using script.soldier;
using UnityEngine;

namespace player
{
    [Serializable]
    [CreateAssetMenu]
    public class Player : ScriptableObject
    {

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

        // private List<Item> shopItems;
        public Player()
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


            //=-=-=-=-=-=-=-

            //=-=-=-=-=-=-=-
        }

        public enum Affinity
        {
            Upper,
            Middle,
            Down
        }
    }
}