using UnityEngine;
using UnityEngine.UI;

namespace script.component
{
    [CreateAssetMenu(fileName = "Character", menuName = "Scriptable Objects/Character", order = 1)]
    public class Character : ScriptableObject
    {
        public Sprite image;
        public string characterName;
    }
}