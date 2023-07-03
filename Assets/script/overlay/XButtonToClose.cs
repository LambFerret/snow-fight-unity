using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes
{
    public class XButtonToClose : MonoBehaviour
    {
        private Button _button;
        private void ClosePanel()
        {
            var panel = _button.transform.parent.GameObject();
            panel.SetActive(false);
        }
        private void Start()
        {
            _button = gameObject.GetComponent<Button>();
            _button.onClick.AddListener(ClosePanel);
        }

    }
}