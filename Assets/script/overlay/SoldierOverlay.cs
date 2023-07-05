using System.Collections.Generic;
using map;
using script.player;
using script.soldier;
using UnityEngine;
using UnityEngine.UI;

namespace script.Overlay
{
    public class SoldierOverlay : MonoBehaviour
    {
        public List<Soldier> soldiers;

        public GameObject prefab;
        // private GameObject _stand;

        public void DispatchSoldiers(int maxSoliderCapacity)
        {
            var player = Player.PlayerInstance;
            if (player.soldiers.Count <= maxSoliderCapacity)
                soldiers.AddRange(player.soldiers);
            else
                for (var i = 0; i < maxSoliderCapacity; i++)
                {
                    var randomSoldierFromPlayer = Random.Range(0, player.soldiers.Count);
                    var randomSoldier = player.soldiers[randomSoldierFromPlayer];
                    soldiers.Add(randomSoldier);
                }

            MakeSoldierOverlay();
        }

        private void MakeSoldierOverlay()
        {
            var stand = prefab.transform.Find("Stand").gameObject;

            var group = gameObject.GetComponent<HorizontalLayoutGroup>();
            foreach (var soldier in soldiers)
            {
                var newSlot = soldier.MakeSoldierStanding(Instantiate(stand));

                newSlot.transform.SetParent(group.transform, false);
            }
        }

        public void EffectTalent(Level.TalentTiming timing)
        {
            foreach (var s in soldiers) s.Talent();
        }
    }
}