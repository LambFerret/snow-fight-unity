using System;

namespace script.player
{
    [Serializable]
    public class SaveLoader
    {
        public Player player;

        // any other data you want to save

        public SaveLoader NewSaveFile()
        {
            return this;
        }

        // You could then have methods for saving and loading the save file:
        public void SaveGame()
        {
            // Serialize this SaveFile object and write it to a file
        }

        public SaveLoader LoadGame()
        {
            return this;
            // Read a file, deserialize it into a SaveFile object, and return it
        }
    }
}