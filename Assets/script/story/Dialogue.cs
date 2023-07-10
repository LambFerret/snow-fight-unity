using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace script.story
{
    public class Dialogue : MonoBehaviour
    {
        public TextMeshProUGUI textComponent;
        public DialogueData[] data;
        public float typingSpeed;

        private int _index;

        private void Start()
        {
            textComponent.text = "";
            StartDialogue();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (textComponent.text == data[_index].sentence) NextLine();
                else
                {
                    StopAllCoroutines();
                    textComponent.text = data[_index].sentence;
                }
            }
        }

        private void StartDialogue()
        {
            _index = 0;
            StartCoroutine(TypeLine());
        }

        private IEnumerator TypeLine()
        {
            foreach (char c in data[_index].sentence)
            {
                textComponent.text += c;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        private void NextLine()
        {
            if (_index < data.Length - 1)
            {
                _index++;
                textComponent.text = "";
                StartCoroutine(TypeLine());
            }
            else
            {
                gameObject.transform.parent.gameObject.SetActive(false);
            }
        }

        [Serializable]
        public struct DialogueData
        {
            public string sentence;
            public string actor;
            public string emotion;
            public string voice;
            public string bgm;
            public string sfx;
        }

    }
}