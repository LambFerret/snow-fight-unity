using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes
{
    public class XButtonToClose : MonoBehaviour
    {
        private Button _button;

        private void Start()
        {
            _button = gameObject.GetComponent<Button>();
            _button.onClick.AddListener(ClosePanel);
        }

        private void ClosePanel()
        {
           _button.transform.parent.GameObject().SetActive(false);
        }
    }
}