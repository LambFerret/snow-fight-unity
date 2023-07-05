using System.Collections.Generic;
using script.command;
using script.soldier;
using UnityEngine;

namespace script.manager
{
    public class ItemLibrary : MonoBehaviour
    {
        public List<Soldier> wholeSoldiers;
        public List<Command> wholeCommands;

        public Soldier GetSoldier(string id)
        {
            foreach (var soldier in wholeSoldiers)
                if (soldier.id == id)
                    return soldier;

            return null;
        }

        public Soldier PopSoldier(string id)
        {
            foreach (var soldier in wholeSoldiers)
                if (soldier.id == id)
                {
                    wholeSoldiers.Remove(soldier);
                    return soldier;
                }

            return null;
        }

        public Command GetCommand(string id)
        {
            foreach (var command in wholeCommands)
                if (command.id == id)
                    return command;

            return null;
        }

        public Command PopCommand(string id)
        {
            foreach (var command in wholeCommands)
                if (command.id == id)
                {
                    wholeCommands.Remove(command);
                    return command;
                }

            return null;
        }
    }
}