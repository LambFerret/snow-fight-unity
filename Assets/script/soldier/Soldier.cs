using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace script.soldier
{
    [Serializable]
    public abstract class Soldier : ScriptableObject
    {
        public enum Branch
        {
            Sniper,
            Administrative,
            Cook,
            Supply,
            Communication,
            Technician,
            Medic,
            Engineer,
            VehicleMaintenance,
            AntiAircraft,
            FireFighter,
            Chemical,
            Infantry,
            Specialist
        }

        public enum EmpowerLevel
        {
            Weaken,
            Neutral,
            Empowered
        }

        public enum Rank
        {
            Recruit = int.MaxValue,
            Private = int.MaxValue,
            PrivateFirstClass = int.MaxValue,
            Corporal = int.MaxValue,
            Sergeant = int.MaxValue,
            StaffSergeant = int.MaxValue,
            SergeantFirstClass = int.MaxValue,
            FirstSergeant = int.MaxValue,
            SergentMajor = int.MaxValue,
            CommandSergeantMajor = int.MaxValue,
            SergeantMajorOfTheArmy = int.MaxValue
        }

        public string id;
        public string soldierName;
        public int rangeX;
        public int rangeY;
        public int speed;
        public int runAwayProbability;
        public EmpowerLevel empowerLevel;
        public List<Terrain> preferenceTerrain;
        public Rank rank;
        public Branch branch;
        public int branchValue;
        protected EmpowerLevel initEmpowerLevel;
        [SerializeField ]protected int initRangeX;
        protected int initRangeY;
        protected int initRunAwayProbability;
        protected int initSpeed;

        protected Soldier(
            string id,
            int rangeX,
            int rangeY,
            int speed,
            int runAwayProbability,
            List<Terrain> preferenceTerrain,
            Rank rank,
            Branch branch
        )
        {
            this.id = id;
            soldierName = id;
            this.rangeX = rangeX;
            this.rangeY = rangeY;
            this.speed = speed;
            this.runAwayProbability = runAwayProbability;
            this.preferenceTerrain = preferenceTerrain;
            this.rank = rank;
            this.branch = branch;
            empowerLevel = EmpowerLevel.Neutral;
            branchValue = 100;
            initRangeX = rangeX;
            initRangeY = rangeY;
            initSpeed = speed;
            initRunAwayProbability = runAwayProbability;
            initEmpowerLevel = empowerLevel;
        }

        public abstract void Talent();

        public GameObject MakeSoldierCard(GameObject card)
        {
            var nameText = card.transform.Find("Name").GetComponent<Text>();
            var xText = card.transform.Find("Panel/x/x").GetComponent<Text>();
            var yText = card.transform.Find("Panel/y/y").GetComponent<Text>();
            var sText = card.transform.Find("Panel/s/s").GetComponent<Text>();
            var rText = card.transform.Find("Panel/r/r").GetComponent<Text>();
            // var portraitText = card.transform.Find("Portrait").GetComponent<Image>();
            var branchText = card.transform.Find("Info/Branch").GetComponent<Text>();

            nameText.text = soldierName;
            xText.text = rangeX.ToString();
            yText.text = rangeY.ToString();
            sText.text = speed.ToString();
            rText.text = runAwayProbability.ToString();
            // portraitText.text = 포트레이트 경로
            branchText.text = branch.ToString();

            return card;
        }

        public GameObject MakeSoldierStanding(GameObject stand)
        {
            stand.transform.Find("Character/Name").GetComponent<Text>().text = id;
            // var standAnimation =

            return stand;
        }

        public void ResetStat()
        {
            rangeX = initRangeX;
            rangeY = initRangeY;
            speed = initSpeed;
            runAwayProbability = initRunAwayProbability;
            empowerLevel = initEmpowerLevel;
        }
    }
}