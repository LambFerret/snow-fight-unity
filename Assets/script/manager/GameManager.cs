using System.Collections.Generic;
using script.command;
using script.component;
using script.player;
using script.soldier;

namespace script.manager
{
    public class GameManager : Singleton<GameManager>

    {
        public ItemLibrary itemLibrary;

        public void Start()
        {
            var soldiers = new List<Soldier>();
            var commands = new List<Command>();

            soldiers.Add(itemLibrary.PopSoldier("Vanilla"));
            soldiers.Add(itemLibrary.PopSoldier("Choco"));
            soldiers.Add(itemLibrary.PopSoldier("Chili"));
            commands.Add(itemLibrary.GetCommand("CupNoodle"));
            commands.Add(itemLibrary.GetCommand("CupNoodle"));
            commands.Add(itemLibrary.GetCommand("CupNoodle"));
            commands.Add(itemLibrary.GetCommand("CupNoodle"));
            commands.Add(itemLibrary.GetCommand("CupNoodle"));
            commands.Add(itemLibrary.GetCommand("CupNoodle"));
            commands.Add(itemLibrary.GetCommand("CupNoodle"));
            commands.Add(itemLibrary.GetCommand("CupNoodleXL"));
            commands.Add(itemLibrary.GetCommand("CupRamen"));

            Player.PlayerInstance.Init(soldiers, commands);
        }
    }
}