using System.Collections.Generic;
using script.command;
using script.soldier;
using UnityEngine;

namespace script.manager
{
    public class ItemLibrary : MonoBehaviour
    {
        public List<Soldier> WholeSoldiers;
        public List<Soldier> SoldiersLeft;
        public List<Command> WholeCommands;

        public void Awake()
        {
            Debug.Log("SoldierLibrary Awake");
            PutSoldiers();
            Debug.Log(WholeSoldiers.Count);
            // PutCommands();
        }

        private void PutSoldiers()
        {
            WholeSoldiers.Add(new Vanilla());
            WholeSoldiers.Add(new Choco());
            WholeSoldiers.Add(new Chili());
            WholeSoldiers.Add(new Coffee());
        }

        private void PutCommands()
        {
            WholeCommands.Add(new CupNoodle());
            WholeCommands.Add(new CupNoodleXL());
            WholeCommands.Add(new CupRamen());
            WholeCommands.Add(new CupRamenXL());
            WholeCommands.Add(new ThreeShift());
            WholeCommands.Add(new TricksOfTrade());
        }
    }
}