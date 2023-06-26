using UnityEngine;
using UnityEngine.UI;

namespace map
{
    public class ExecuteBehavior : MonoBehaviour
    {
        public Level LevelData;

        private void Start()
        {
            gameObject.GetComponent<Button>().onClick.AddListener(LevelData.NextPhase);
        }
    }
}