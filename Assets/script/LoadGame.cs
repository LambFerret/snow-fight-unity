using System.IO;
using script.player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace script
{
    public class LoadGame : MonoBehaviour
    {
        public Player player;
        private Button _button;

        private void Start()
        {
            _button = gameObject.GetComponent<Button>();
            _button.onClick.AddListener(LoadGameOnClick);
        }

        private void LoadGameOnClick()
        {
            // Path to the save file
            var path = Application.persistentDataPath + "/savefile.save";

            // Check if the save file exists
            if (File.Exists(path))
            {
                // Load the save file
                var saveData = File.ReadAllText(path);
                Debug.Log(saveData);
            }
            else
            {
                File.WriteAllText(path, "hi i am Player");
                Debug.Log("No save file found at " + path);
            }

            // Change the scene - replace "YourSceneName" with the name of your scene
            SceneManager.LoadScene("GroundScene");
        }
    }
}