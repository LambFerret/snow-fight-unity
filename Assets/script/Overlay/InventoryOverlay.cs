using System;
using script.manager;
using UnityEngine;
using UnityEngine.UI;

namespace map
{
    public class InventoryOverlay : MonoBehaviour
    {
        public ItemLibrary itemLibrary;
        public GameObject soldierPrefab;

        private void Start()
        {
            var group = gameObject.GetComponent<GridLayoutGroup>();
            Debug.Log(itemLibrary.WholeSoldiers.Count);
            Debug.Log("s.name");

            foreach (var s in itemLibrary.WholeSoldiers)
            {
                Debug.Log(s.name);
                var a = Instantiate(soldierPrefab);
                var soldier = s.MakeSoldierPrefab(a);
                soldier.transform.SetParent(group.transform, false);
            }
        }
    }
}