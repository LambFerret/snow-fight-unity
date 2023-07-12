using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using script.component;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace script.story
{
    public class Dialogue : MonoBehaviour
    {
        public TextMeshProUGUI textComponent;
        public DialogueData[] data;
        public float typingSpeed;
        public Color defaultColor;
        public Color highlightColor;

        public List<Character> leftCharacters;
        public GameObject leftSpeaker;
        public GameObject leftLabel;
        private List<Vector3> _leftCharacterPositions;
        private List<Image> _leftCharacterImages;
        private TextMeshProUGUI _leftLabel;

        public List<Character> rightCharacters;
        public GameObject rightSpeaker;
        public GameObject rightLabel;
        private List<Vector3> _rightCharacterPositions;
        private List<Image> _rightCharacterImages;
        private TextMeshProUGUI _rightLabel;

        private int _index;

        private void Start()
        {
            data = temp();
            _leftCharacterImages = new List<Image>();
            _rightCharacterImages = new List<Image>();
            textComponent.text = "";
            _leftLabel = leftLabel.transform.Find("LeftLabelText").GetComponent<TextMeshProUGUI>();
            _rightLabel = rightLabel.transform.Find("RightLabelText").GetComponent<TextMeshProUGUI>();

            _leftCharacterImages = AddCharactersToSpeaker(leftSpeaker, leftCharacters);
            _rightCharacterImages = AddCharactersToSpeaker(rightSpeaker, rightCharacters);

            _rightCharacterPositions = _rightCharacterImages.Select(image => image.transform.position).ToList();
            _leftCharacterPositions = _leftCharacterImages.Select(image => image.transform.position).ToList();

            StartDialogue();
            ChangeSpeakingActor(data[_index].actor);
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

        private List<Image> AddCharactersToSpeaker(GameObject speaker, List<Character> characters)
        {
            List<Image> characterImages = new List<Image>();

            foreach (var character in characters)
            {
                Image image = new GameObject(character.characterName).AddComponent<Image>();
                image.sprite = character.image;
                image.color = defaultColor;
                image.transform.SetParent(speaker.transform, false);
                characterImages.Add(image);
            }

            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)speaker.transform);

            return characterImages;
        }

        private void UpdateCharacter(string actorName, List<Character> characters, List<Image> characterImages, List<Vector3> characterPositions, TextMeshProUGUI label, GameObject labelObject)
        {
            labelObject.SetActive(true);
            label.text = actorName;
            for (int i = 0; i < characters.Count; i++)
            {
                if (characters[i].characterName == actorName)
                {
                    Character speakingActor = characters[i];
                    characters.RemoveAt(i);
                    characters.Add(speakingActor);

                    Image speakingActorImage = characterImages[i];
                    characterImages.RemoveAt(i);
                    characterImages.Add(speakingActorImage);

                    for (int j = 0; j < characterImages.Count; j++)
                    {
                        Image image = characterImages[j];
                        Vector3 finalPosition = characterPositions[j];
                        image.rectTransform.DOMove(finalPosition, 0.5f).SetEase(Ease.OutBack);
                    }

                    HighlightActor(characterImages);
                    break;
                }
            }
        }

        private void ChangeSpeakingActor(string actorName)
        {
            bool isLeft = false;
            foreach (var character in leftCharacters)
            {
                if (character.characterName == actorName)
                {
                    isLeft = true;
                    break;
                }
            }

            if (isLeft)
            {
                UpdateCharacter(actorName, leftCharacters, _leftCharacterImages, _leftCharacterPositions, _leftLabel, leftLabel);
                rightLabel.SetActive(false);
            }
            else
            {
                UpdateCharacter(actorName, rightCharacters, _rightCharacterImages, _rightCharacterPositions, _rightLabel, rightLabel);
                leftLabel.SetActive(false);
            }
        }

        private void HighlightActor(List<Image> characterImages)
        {
            for (int i = 0; i < characterImages.Count; i++)
            {
                characterImages[i].color = defaultColor;
                characterImages[i].transform.SetSiblingIndex(i);
            }

            characterImages[^1].color = highlightColor;
            characterImages[^1].transform.SetAsLastSibling();
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
                ChangeSpeakingActor(data[_index].actor);
                textComponent.text = "";
                StartCoroutine(TypeLine());
            }
            else
            {
                gameObject.transform.parent.gameObject.SetActive(false);
            }
        }

        private DialogueData[] temp()
        {
            var data = new DialogueData[10];
            data.SetValue(new DialogueData
            {
                sentence = "Hello, my name is John.",
                actor = "Chili",
                emotion = "Happy",
                voice = "John",
                bgm = "John",
                sfx = "John"
            }, 0);
            data.SetValue(new DialogueData
            {
                sentence = "Hello, my name is John.",
                actor = "John",
                emotion = "Choco",
                voice = "John",
                bgm = "John",
                sfx = "John"
            }, 1);
            data.SetValue(new DialogueData
            {
                sentence = "Hello, my name is John.",
                actor = "Vanilla",
                emotion = "Happy",
                voice = "John",
                bgm = "John",
                sfx = "John"
            }, 2);
            data.SetValue(new DialogueData
            {
                sentence = "Hello, my name is John.",
                actor = "Coffee",
                emotion = "Happy",
                voice = "John",
                bgm = "John",
                sfx = "John"
            }, 3);
            data.SetValue(new DialogueData
            {
                sentence = "Hello, my name is John.",
                actor = "Chili",
                emotion = "Happy",
                voice = "John",
                bgm = "John",
                sfx = "John"
            }, 4);
            data.SetValue(new DialogueData
            {
                sentence = "Hello, my name is John.",
                actor = "Choco",
                emotion = "Happy",
                voice = "John",
                bgm = "John",
                sfx = "John"
            }, 5);
            data.SetValue(new DialogueData
            {
                sentence = "Hello, my name is John.",
                actor = "Chili",
                emotion = "Happy",
                voice = "John",
                bgm = "John",
                sfx = "John"
            }, 6);
            data.SetValue(new DialogueData
            {
                sentence = "Hello, my name is John.",
                actor = "Vanilla",
                emotion = "Happy",
                voice = "John",
                bgm = "John",
                sfx = "John"
            }, 7);
            data.SetValue(new DialogueData
            {
                sentence = "Hello, my name is John.",
                actor = "Coffee",
                emotion = "Happy",
                voice = "John",
                bgm = "John",
                sfx = "John"
            }, 8);
            data.SetValue(new DialogueData
            {
                sentence = "Hello, my name is John.",
                actor = "Vanilla",
                emotion = "Happy",
                voice = "John",
                bgm = "John",
                sfx = "John"
            }, 9);
            return data;
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