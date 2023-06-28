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
        [SerializeField] private Player _player;

        private void Start()
        {
            _player = GameManager.Instance.player;
            var playerSoldier = _player.soldiers;

            var group = gameObject.GetComponent<GridLayoutGroup>();
            foreach (var s in playerSoldier)
            {
                var soldier = s.MakeSoldierCard(Instantiate(soldierPrefab));
                soldier.transform.SetParent(group.transform, false);
            }
        }
    }
}