namespace script.manager
{
    public class GameManager : Singleton<GameManager>

    {
        public static player.Player Player;
        // public static SoldierLibrary SoldierLibrary;

        public override void Awake()
        {
            // SoldierLibrary = gameObject.AddComponent<SoldierLibrary>();

        }
    }
}