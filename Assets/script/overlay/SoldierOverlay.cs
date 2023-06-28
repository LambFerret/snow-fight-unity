using System;
using System.Collections.Generic;
using script.soldier;
using UnityEngine;
using UnityEngine.UI;

namespace script.Overlay
{
    public class SoldierOverlay : MonoBehaviour
    {
        [SerializeField] private List<Soldier> soldiers;
        public GameObject soldierPrefab;

        public void SetWorkingSolider(List<Soldier> soldiers)
        {
            var group = gameObject.GetComponent<HorizontalLayoutGroup>();
            foreach (var soldier in soldiers)
            {
                var newSlot = soldier.MakeSoldierStanding(Instantiate(soldierPrefab));
                newSlot.transform.SetParent(group.transform, false);
            }
        }


    }
}