using script.component;
using script.player;

namespace script.manager
{
    public class GameManager : Singleton<GameManager>

    {
        public ItemLibrary itemLibrary;

        public void Start()
        {
            foreach (var soldier in Player.PlayerInstance.soldiers)
            {
                itemLibrary.PopSoldier(soldier.id);
            }
        }
    }
}