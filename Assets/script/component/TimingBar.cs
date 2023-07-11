using System;
using UnityEngine.UI;
using UnityEngine;

namespace script.component
{
    public class TimingBar : MonoBehaviour
    {

        public Slider slider;
        public float speed = 0.5f;
        public KeyCode pressKey = KeyCode.Space;
        public GameObject knob;
        public GameObject perfectArea;
        private bool _gameStarted;
        private Collider2D _knobCollider2D;
        private Collider2D _perfectAreaCollider2D;
        private void Start()
        {
            _knobCollider2D = knob.GetComponent<Collider2D>();
            _perfectAreaCollider2D = perfectArea.GetComponent<Collider2D>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _gameStarted = true;
            }

            if (_gameStarted)
            {
                var boundsA = _knobCollider2D.bounds;
                var boundsB = _perfectAreaCollider2D.bounds;
                slider.value += speed * Time.deltaTime;

                if (slider.value >= 1f)
                {
                    // Debug.Log("FAILED");
                    // gameObject.SetActive(false);
                    ResetValue();
                }

                if (Input.GetKeyDown(pressKey))
                {
                    // Check if the knob is in the red zone
                    if (boundsB.Contains(boundsA.min) && boundsB.Contains(boundsA.max))
                    {
                        Debug.Log("PERFECT");
                        // gameObject.SetActive(false);
                    }
                    else
                    {
                        Debug.Log("FAILED");
                        // gameObject.SetActive(false);
                    }

                    ResetValue();
                }
            }
        }

        private void ResetValue()
        {
            slider.value = 0;
        }
    }
}