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
            var card = soldierPrefab.transform.Find("Card").gameObject;

            var group = gameObject.GetComponent<GridLayoutGroup>();
            foreach (var s in playerSoldier)
            {
                var soldier = s.MakeSoldierCard(Instantiate(card));
                soldier.transform.SetParent(group.transform, false);
            }
        }
    }
}