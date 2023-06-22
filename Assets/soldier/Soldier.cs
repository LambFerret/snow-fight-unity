using System.Collections.Generic;
using UnityEngine;

namespace soldier
{
    [System.Serializable]
    public abstract class Soldier
    {
        public abstract void Talent();
        ///<summary>
        ///ID, 밑으로 기본적인 정보들
        ///</summary>
        public string id;

        ///<summary>
        ///이름
        ///</summary>
        public string name;

        ///<summary>
        ///한마디?
        ///</summary>
        public string description;

        ///<summary>
        ///선호 지형
        ///</summary>
        public List<Terrain> preferenceTerrain;

        ///<summary>
        ///속도, 밑으로 수치관련 정보
        ///</summary>
        public short speed;

        ///<summary>
        ///특수한 가로세로 범위
        ///</summary>
        public bool isUncommonRange;

        ///<summary>
        ///가로 범위
        ///</summary>
        public byte rangeX;

        ///<summary>
        ///세로 범위
        ///</summary>
        public byte rangeY;

        ///<summary>
        ///현재 강화 수치
        ///</summary>
        public EmpowerLevel empowerLevel;

        ///<summary>
        ///직급, 밑으로 능력관련 정보
        ///</summary>
        public Rank rank;

        ///<summary>
        ///병과
        ///</summary>
        public Branch branch;

        ///<summary>
        ///재능 관련 설명
        ///</summary>
        public string talent;

        ///<summary>
        ///강화
        ///</summary>
        public string empower;

        ///<summary>
        ///약화
        ///</summary>
        public string weaken;

        ///<summary>
        ///도망 확률
        ///</summary>
        public byte runAwayProbability;

        public int branchValue = 100;

        public enum Branch
        {
            ///<summary>
            ///저격병
            ///</summary>
            Sniper,

            ///<summary>
            ///행정병
            ///</summary>
            Administrative,

            ///<summary>
            ///취사병
            ///</summary>
            Cook,

            ///<summary>
            ///보급병
            ///</summary>
            Supply,

            ///<summary>
            ///통신병
            ///</summary>
            Communication,

            ///<summary>
            ///기술병
            ///</summary>
            Technician,

            ///<summary>
            ///의무병
            ///</summary>
            Medic,

            ///<summary>
            ///공병
            ///</summary>
            Engineer,

            ///<summary>
            ///차량정비병
            ///</summary>
            VehicleMaintenance,

            ///<summary>
            ///방공병
            ///</summary>
            AntiAircraft,

            ///<summary>
            ///방화병
            ///</summary>
            FireFighter,

            ///<summary>
            ///화생방병
            ///</summary>
            Chemical,

            ///<summary>
            ///보병
            ///</summary>
            Infantry,

            ///<summary>
            ///특수전문병
            ///</summary>
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
            ///<summary>
            ///훈련병
            ///</summary>
            Recruit = int.MaxValue,

            ///<summary>
            ///이등병
            ///</summary>
            Private = int.MaxValue,

            ///<summary>
            ///일등병
            ///</summary>
            PrivateFirstclass = int.MaxValue,

            ///<summary>
            ///상병
            ///</summary>
            Corporal = int.MaxValue,

            ///<summary>
            ///병장
            ///</summary>
            Sergeant = int.MaxValue,

            ///<summary>
            ///하사
            ///</summary>
            StaffSergeant = int.MaxValue,

            ///<summary>
            ///중사
            ///</summary>
            SergeantFirstclass = int.MaxValue,

            ///<summary>
            ///상사
            ///</summary>
            FirstSergeant = int.MaxValue,

            ///<summary>
            ///원사
            ///</summary>
            SergentMajor = int.MaxValue,

            ///<summary>
            ///주임원사
            ///</summary>
            CommandSergeantMajor = int.MaxValue,

            ///<summary>
            ///육군주임원사
            ///</summary>
            SergeantMajorOfTheArmy = int.MaxValue,

            ///<summary>
            ///준위
            ///</Summary> int.MaxValue,
            MasterWarrantOfficer = int.MaxValue,

            ///<summary>
            ///소위
            ///</summary>
            SecondLieutenant = int.MaxValue,

            ///<summary>
            ///중위
            ///</summary>
            FirstLieutenant = int.MaxValue,

            ///<summary>
            ///대위
            ///</summary>
            Captain = int.MaxValue,

            ///<summary>
            ///소령
            ///</summary>
            Major = int.MaxValue,

            ///<summary>
            ///중령
            ///</summary>
            LieutenantColonel = int.MaxValue,

            ///<summary>
            ///대령
            ///</summary>
            Colonel = int.MaxValue,

            ///<summary>
            ///준장
            ///</summary>
            BrigadierGeneral = int.MaxValue,

            ///<summary>
            ///소장
            ///</summary>
            MajorGeneral = int.MaxValue,

            ///<summary>
            ///중장
            ///</summary>
            LieutenantGeneral = int.MaxValue,

            ///<summary>
            ///대장
            ///</summary>
            General = int.MaxValue,

        }

    }

    [System.Serializable]
    public class Vanilla : Soldier
    {
        public override void Talent()
        {
            throw new System.NotImplementedException();
        }
    }
}