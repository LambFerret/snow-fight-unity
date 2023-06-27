using System;
using script.manager;
using UnityEngine;
using UnityEngine.UI;

namespace script.Overlay
{
    public class InventoryOverlay : MonoBehaviour
    {
        public ItemLibrary itemLibrary;
        public GameObject soldierPrefab;

        private void Start()
        {
            var group = gameObject.GetComponent<GridLayoutGroup>();
            foreach (var s in itemLibrary.wholeSoldiers)
            {
                var soldier = s.MakeSoldierPrefab(Instantiate(soldierPrefab));
                soldier.transform.SetParent(group.transform, false);
            }
        }
    }
}