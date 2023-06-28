using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace script.soldier
{
    [Serializable]
    public class Soldier :MonoBehaviour
    {
        public string id;
        public string soldierName;
        public int rangeX;
        public int rangeY;
        public int speed;
        public int runAwayProbability;
        public List<Terrain> preferenceTerrain;
        public Rank rank = Rank.Private;
        public Branch branch = Branch.Administrative;
        public EmpowerLevel empowerLevel = EmpowerLevel.Neutral;
        public int branchValue = 100;

        public delegate void EffectTalent();

        public EffectTalent Talent;

        public GameObject MakeSoldierCard(GameObject prefab)
        {
            GameObject card = prefab.transform.Find("Card").gameObject;
            card.SetActive(true);
            var nameText = card.transform.Find("Name").GetComponent<Text>();
            var xText = card.transform.Find("Panel/x/x").GetComponent<Text>();
            var yText = card.transform.Find("Panel/y/y").GetComponent<Text>();
            var sText = card.transform.Find("Panel/s/s").GetComponent<Text>();
            var rText = card.transform.Find("Panel/r/r").GetComponent<Text>();
            // var portraitText = card.transform.Find("Portrait").GetComponent<Image>();
            var branchText = card.transform.Find("Info/Branch").GetComponent<Text>();

            nameText.text = id;
            xText.text = rangeX.ToString();
            yText.text = rangeY.ToString();
            sText.text = speed.ToString();
            rText.text = runAwayProbability.ToString();
            // portraitText.text = 포트레이트 경로
            branchText.text = branch.ToString();

            return card;
        }

        public GameObject MakeSoldierStanding(GameObject prefab)
        {
            var stand = prefab.transform.Find("Stand/Character").gameObject;
            stand.SetActive(true);
            // var standAnimation =
            return stand;
        }

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