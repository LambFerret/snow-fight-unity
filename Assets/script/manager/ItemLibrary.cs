using System.Collections.Generic;
using script.command;
using script.soldier;
using UnityEngine;
using UnityEngine.Serialization;

namespace script.manager
{
    public class ItemLibrary : MonoBehaviour
    {
        public List<Soldier> wholeSoldiers;
        public List<Soldier> soldiersLeft;
        public List<Command> wholeCommands;

        public void Awake()
        {
            Debug.Log("SoldierLibrary Awake");
            PutSoldiers();
            PutCommands();
        }

        private void PutSoldiers()
        {
            wholeSoldiers.Add(new Vanilla());
            wholeSoldiers.Add(new Choco());
            wholeSoldiers.Add(new Chili());
            wholeSoldiers.Add(new Coffee());
        }

        private void PutCommands()
        {
            wholeCommands.Add(new CupNoodle());
            wholeCommands.Add(new CupNoodleXL());
            wholeCommands.Add(new CupRamen());
            wholeCommands.Add(new CupRamenXL());
            wholeCommands.Add(new ThreeShift());
            wholeCommands.Add(new TricksOfTrade());
        }

        public Soldier GetSoldier(string id)
        {
            foreach (var soldier in wholeSoldiers)
            {
                if (soldier.id == id)
                {
                    return soldier;
                }
            }
            return null;
        }

        public Soldier PopSoldier(string id)
        {
            foreach (var soldier in soldiersLeft)
            {
                if (soldier.id == id)
                {
                    soldiersLeft.Remove(soldier);
                    return soldier;
                }
            }
            return null;
        }

        public Command GetCommand(string id)
        {
            foreach (var command in wholeCommands)
            {
                if (command.id == id)
                {
                    return command;
                }
            }
            return null;
        }

        public Command PopCommand(string id)
        {
            foreach (var command in wholeCommands)
            {
                if (command.id == id)
                {
                    wholeCommands.Remove(command);
                    return command;
                }
            }
            return null;
        }


    }
}