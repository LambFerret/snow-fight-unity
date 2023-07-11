using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace script.story
{
    public class Dialogue : MonoBehaviour
    {
        public TextMeshProUGUI textComponent;
        public DialogueData[] data;
        public float typingSpeed;

        public List<Image> actorImages; // Assign these in the inspector.
        public Color defaultColor; // The color for non-highlighted actors.
        public Color highlightColor; // The color for the highlighted actor.

        private int _index;

        private void Start()
        {
            textComponent.text = "";
            StartDialogue();
            foreach (var image in actorImages)
            {
                image.color = defaultColor;
            }

            // Highlight the last actor at start.
            HighlightLastActor();
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

        public void ChangeSpeakingActor(int actorIndex)
        {
            if (actorIndex >= 0 && actorIndex < actorImages.Count)
            {
                // Swap the speaking actor to the end of the list.
                Image speakingActor = actorImages[actorIndex];
                actorImages.RemoveAt(actorIndex);
                actorImages.Add(speakingActor);

                // Highlight the new last actor.
                HighlightLastActor();
            }
        }

        private void HighlightLastActor()
        {
            // First, set all actors to the default color.
            foreach (var image in actorImages)
            {
                image.color = defaultColor;
                image.transform.SetSiblingIndex(actorImages.IndexOf(image));
            }

            // Then, highlight the last actor.
            actorImages[^1].color = highlightColor;
            actorImages[^1].transform.SetAsLastSibling();
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
                ChangeSpeakingActor(_index);
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