using System.Collections.Generic;
using script.component;
using script.map;
using script.player;
using script.soldier;
using UnityEngine;
using UnityEngine.UI;

namespace script.Overlay
{
    public class SoldierOverlay : MonoBehaviour
    {
        public GameObject prefab;
        private HorizontalLayoutGroup _horizontalLayoutGroup;
        private List<Soldier> _soldiers;

        public void DispatchSoldiers(int maxSoliderCapacity)
        {
            var player = Player.PlayerInstance;
            _soldiers = player.soldiersInThisLevel;
            List<Soldier> temp = new List<Soldier>();
            temp.AddRange(player.soldiers);
            _soldiers.Clear();
            _horizontalLayoutGroup = gameObject.GetComponent<HorizontalLayoutGroup>();
            if (temp.Count <= maxSoliderCapacity)
                _soldiers.AddRange(temp);
            else
                for (var i = 0; i < maxSoliderCapacity; i++)
                {
                    var randomSoldierFromPlayer = Random.Range(0, temp.Count);
                    var randomSoldier = temp[randomSoldierFromPlayer];
                    randomSoldier.ResetStat();
                    _soldiers.Add(randomSoldier);
                    temp.RemoveAt(randomSoldierFromPlayer);
                }

            MakeSoldierOverlay();
        }

        private void MakeSoldierOverlay()
        {
            var stand = prefab.transform.Find("Stand").gameObject;

            foreach (var soldier in _soldiers)
            {
                var newSlot = soldier.MakeSoldierStanding(Instantiate(stand));
                var hoverTooltip = newSlot.GetComponent<HoverTooltip>();
                hoverTooltip.soldier = soldier;
                newSlot.transform.SetParent(_horizontalLayoutGroup.transform, false);
            }
        }

        public void EffectTalent(Level.TalentTiming timing)
        {
            foreach (var s in _soldiers) s.Talent();
        }
    }
}