using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace script.overlay
{
    public class ButtonManager : MonoBehaviour
    {
        public GameObject victoryPanel;
        public GameObject defeatPanel;


        public void CloseResultPanel()
        {
            victoryPanel.SetActive(false);
            defeatPanel.SetActive(false);
        }
    }
}