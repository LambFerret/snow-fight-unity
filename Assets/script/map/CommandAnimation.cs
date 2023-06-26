using UnityEngine;

namespace script.map
{
    public class CommandAnimation : MonoBehaviour
    {
        private Animator _animator;
        private int isEnteredHash;
        private int isClickedHash;
        private int isDisabledHash;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            isEnteredHash = Animator.StringToHash("isEntered");
            isClickedHash = Animator.StringToHash("isClicked");
            isDisabledHash = Animator.StringToHash("isDisabled");
            Debug.Log("CommandAnimation Awake" + _animator.parameterCount);
        }

        private void OnMouseEnter()
        {
            _animator.SetBool(isEnteredHash, true);
            Debug.Log("CommandAnimation OnMouseEnter");
        }

        private void OnMouseExit()
        {
            _animator.SetBool(isEnteredHash, false);
            Debug.Log("CommandAnimation OnMouseExit");
        }

        private void OnMouseUp()
        {
            _animator.SetBool(isClickedHash, true);
            Debug.Log("CommandAnimation OnMouseUp");
        }

        private void OnCommandDisabled()
        {
            _animator.SetBool(2, true);
        }
    }
}