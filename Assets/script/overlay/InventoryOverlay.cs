using System;
using script.manager;
using script.player;
using UnityEngine;
using UnityEngine.UI;

namespace script.overlay
{
    public class InventoryOverlay : MonoBehaviour
    {
        public GameObject soldierPrefab;

        private void Start()
        {
            var player = Player.PlayerInstance;
            var playerSoldier = player.soldiers;

            var group = gameObject.GetComponent<GridLayoutGroup>();
            foreach (var s in playerSoldier)
            {
                var soldier = s.MakeSoldierCard(Instantiate(soldierPrefab.transform.Find("Card").gameObject));
                soldier.transform.SetParent(group.transform, false);
            }
        }
    }
}