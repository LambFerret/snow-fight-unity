using map;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace script.overlay
{
    public class ExecuteBehavior : MonoBehaviour
    {
        public Level levelData;

        private void Start()
        {
            gameObject.GetComponent<Button>().onClick.AddListener(levelData.NextPhase);
        }
    }
}