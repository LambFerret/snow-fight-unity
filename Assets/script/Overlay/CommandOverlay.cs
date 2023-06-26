using UnityEngine;
using UnityEngine.Serialization;

namespace map
{
    public class CommandOverlay : MonoBehaviour
    {
        public GameObject slot;
        public GameObject panel;
        public player.Player player;

        private void Start()
        {
            CreateCommandOverlay();
        }

        private void CreateCommandOverlay()
        {

            for (int i = 0; i < player.maxCommandInHand; i++)
            {
                // GameObject command = Instantiate()
                GameObject newSlot = Instantiate(slot, panel.transform);
                var childRect = newSlot.GetComponent<RectTransform>();
                var parentRect = panel.GetComponent<RectTransform>().rect;
                var sizeDelta = childRect.sizeDelta;
                float parentHeight = parentRect.height;
                float aspectRatio = sizeDelta.x / sizeDelta.y;
                childRect.sizeDelta = new Vector2(parentHeight * aspectRatio, parentHeight);
                float newX = (parentRect.width * i) / player.maxCommandInHand + parentRect.xMin + childRect.rect.width / 2;
                childRect.anchoredPosition = new Vector2(newX, 0);
            }
        }
    }
}