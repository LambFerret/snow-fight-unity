using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.title
{
    public class TitleButtonController : MonoBehaviour
    {
        public GameObject askPanel, optionPanel;
        public string groundSceneName;

        public void NewGameOnClick()
        {
            string path = Application.persistentDataPath + "/player.save";
            if(File.Exists(path))
            {
                askPanel.SetActive(true);
            }
            else
            {
                Confirm();
            }
        }

        public void Confirm()
        {
            SceneManager.LoadScene(groundSceneName);
        }

        public void Abort()
        {
            askPanel.SetActive(false);
        }

        public void ContinueOnClick()
        {
            Debug.Log("Continue");
        }

        public void OptionOnClick()
        {
            optionPanel.SetActive(true);
            Debug.Log("Option");
        }

        public void OptionExit()
        {
            optionPanel.SetActive(false);
        }

        public void OptionSave()
        {
            // Save
            OptionExit();
        }

        public void QuitOnClick()
        {
            Application.Quit();
        }
    }
}