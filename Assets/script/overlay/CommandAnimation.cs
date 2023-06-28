using UnityEngine;

namespace script.overlay
{
    public class CommandAnimation : MonoBehaviour
    {
        private Animator _animator;
        private int _isEnteredHash;
        private int _isClickedHash;
        private int _isDisabledHash;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _isEnteredHash = Animator.StringToHash("isEntered");
            _isClickedHash = Animator.StringToHash("isClicked");
            _isDisabledHash = Animator.StringToHash("isDisabled");
        }

        private void OnMouseEnter()
        {
            _animator.SetBool(_isEnteredHash, true);
        }

        private void OnMouseExit()
        {
            _animator.SetBool(_isEnteredHash, false);
        }

        private void OnMouseUp()
        {
            _animator.SetBool(_isEnteredHash, false);
            _animator.SetBool(_isClickedHash, true);
        }

        private void OnCommandDisabled()
        {
            _animator.SetBool(_isDisabledHash, true);
        }
    }
}