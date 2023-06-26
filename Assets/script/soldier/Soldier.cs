using System.Collections.Generic;
using UnityEngine;

namespace script.soldier
{
    public class Soldier : MonoBehaviour
    {
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