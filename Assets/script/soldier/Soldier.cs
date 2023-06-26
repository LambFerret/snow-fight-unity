using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace script.soldier
{
    [Serializable]
    public class Soldier
    {
        public string name;
        public int rangeX;
        public int rangeY;
        public int speed;
        public int runAwayProbability;
        public List<Terrain> preferenceTerrain;
        public Rank rank = Rank.Private;
        public Branch branch = Branch.Administrative;
        public EmpowerLevel empowerLevel = EmpowerLevel.Neutral;
        public int branchValue = 100;

        public GameObject MakeSoldierPrefab(GameObject prefab)
        {
            var nameText = prefab.transform.Find("Card/Name").GetComponent<Text>();
            var xText = prefab.transform.Find("Card/Panel/x/x").GetComponent<Text>();
            var yText = prefab.transform.Find("Card/Panel/y/y").GetComponent<Text>();
            var sText = prefab.transform.Find("Card/Panel/s/s").GetComponent<Text>();
            var rText = prefab.transform.Find("Card/Panel/r/r").GetComponent<Text>();
            // var portraitText = prefab.transform.Find("Card/Portrait").GetComponent<Text>();
            var branchText = prefab.transform.Find("Card/Info/Branch").GetComponent<Text>();

            nameText.text = name;
            xText.text = rangeX.ToString();
            yText.text = rangeY.ToString();
            sText.text = speed.ToString();
            rText.text = runAwayProbability.ToString();
            // portraitText.text = 포트레이트 경로
            branchText.text = branch.ToString();

            return prefab;
        }

        public delegate void EffectTalent();

        public EffectTalent Talent;

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
            PrivateFirstclass = int.MaxValue,
            Corporal = int.MaxValue,
            Sergeant = int.MaxValue,
            StaffSergeant = int.MaxValue,
            SergeantFirstclass = int.MaxValue,
            FirstSergeant = int.MaxValue,
            SergentMajor = int.MaxValue,
            CommandSergeantMajor = int.MaxValue,
            SergeantMajorOfTheArmy = int.MaxValue
        }
    }
}