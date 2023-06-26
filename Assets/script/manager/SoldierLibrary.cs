using System.Collections.Generic;
using script.soldier;
using UnityEngine;

namespace script.manager
{
    public class SoldierLibrary : MonoBehaviour
    {
        public static  HashSet<Soldier> WholeSoldiers;
        public static  List<Soldier> SoldiersLeft;

        public void Awake()
        {
            Debug.Log("SoldierLibrary Awake");
            WholeSoldiers.Add(gameObject.AddComponent<Vanilla>());
        }
    }
}