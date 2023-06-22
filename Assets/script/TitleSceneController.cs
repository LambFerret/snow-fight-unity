using UnityEngine;
using UnityEngine.UI;

namespace Scenes
{
    public class TitleSceneController : MonoBehaviour
    {
        public Button newGameButton, loadGameButton, optionButton, quitButton;
        public GameObject newGameCanvas, loadGameCanvas, optionCanvas;


        private void ToggleNewGameCanvas()
        {
            newGameCanvas.SetActive(true);
        }

        private void ToggleLoadGameCanvas()
        {
            loadGameCanvas.SetActive(true);
        }

        private void ToggleOptionCanvas()
        {
            optionCanvas.SetActive(true);
        }

        private static void QuitGame()
        {
            Debug.Log("Quit");
            Application.Quit();
        }

        private void Start()
        {
            newGameButton.onClick.AddListener(ToggleNewGameCanvas);
            loadGameButton.onClick.AddListener(ToggleLoadGameCanvas);
            optionButton.onClick.AddListener(ToggleOptionCanvas);
            quitButton.onClick.AddListener(QuitGame);
        }
    }
}