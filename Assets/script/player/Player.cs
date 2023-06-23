using System;
using System.Collections.Generic;
using script.command;
using soldier;
using UnityEngine;

namespace player
{
    [Serializable]
    [CreateAssetMenu]
    public class Player : ScriptableObject
    {

        // private List<Manual> manuals;
        // private List<Quest> quests;
        public Soldier[] Soldiers { get; set; }
        private Command[] Commands { get; set; }
        public int ClearedMainQuestNumber { get;  set; }
        public int Day { get;  set; }
        public int Money { get;  set; }
        public int MaxCost { get;  set; }
        public int CurrentCost { get;  set; }
        public int Difficulty { get;  set; }
        public int SnowAmount { get;  set; }
        public int MiddleAffinity { get;  set; }
        public int DownAffinity { get;  set; }
        public int UpperAffinity { get;  set; }
        public int MaxManualCapacity { get;  set; }
        public int MaxCommandInHand { get;  set; }

        // private List<Item> shopItems;
        public Player()
        {
            Day = 0;
            Money = 1000;
            MaxCost = 15;
            CurrentCost = MaxCost;
            Difficulty = 0;
            ClearedMainQuestNumber = 0;
            DownAffinity = 10;
            MiddleAffinity = 50;
            UpperAffinity = 10;
            MaxManualCapacity = 3;
            MaxCommandInHand = 5;


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