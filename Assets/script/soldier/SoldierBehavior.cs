using UnityEngine;

namespace soldier
{
    public class SoldierBehavior : MonoBehaviour
    {
        public Soldier SoldierData;

        private void Start()
        {
            SoldierData = new Vanilla();
        }

        private void Update()
        {

        }
    }
}