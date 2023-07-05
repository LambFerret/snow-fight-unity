using script.manager;
using UnityEngine;
using UnityEngine.UI;

namespace script.overlay
{
    public class ExecuteBehavior : MonoBehaviour
    {
        public PhaseSystem system;
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(system.NextPhase);
        }

        private void Update()
        {
            if (system.currentPhase == PhaseSystem.PhaseState.Post)
                _button.interactable = false;
            else
                _button.interactable = true;
        }
    }
}