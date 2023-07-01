

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
            List<Soldier> soldiers = new List<Soldier>();
            List<Command> commands = new List<Command>();

            soldiers.Add(itemLibrary.PopSoldier("Vanilla"));
            soldiers.Add(itemLibrary.PopSoldier("Choco"));
            soldiers.Add(itemLibrary.PopSoldier("Chili"));
            commands.Add(itemLibrary.PopCommand("CupNoodle"));
            commands.Add(itemLibrary.PopCommand("CupNoodleXL"));
            commands.Add(itemLibrary.PopCommand("CupRamen"));

            Player.PlayerInstance.Init(soldiers, commands);
        }
    }
}