using System.Collections.Generic;
using soldier;
using UnityEngine;

namespace script
{
    public class PhaseGameManager : MonoBehaviour
    {
        public List<Soldier> soldiers = new List<Soldier>();
        public Transform[] soldierSlot;
        public bool[] availableSlot;

        public void DrawCard()
        {

        }
    }
}