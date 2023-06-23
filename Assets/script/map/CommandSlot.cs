using UnityEngine;

namespace map
{
    public class CommandSlot : MonoBehaviour
    {
        public GameObject slotPrefab;
        public GameObject panel;
        public player.Player player;

        private void Start()
        {
            CreateMagicSlots();
        }

        private void CreateMagicSlots()
        {

            for (int i = 0; i < player.MaxCommandInHand; i++)
            {
                GameObject newSlot = Instantiate(slotPrefab, panel.transform);
                var childRect = newSlot.GetComponent<RectTransform>();
                var parentRect = panel.GetComponent<RectTransform>().rect;
                var sizeDelta = childRect.sizeDelta;
                float parentHeight = parentRect.height;
                float aspectRatio = sizeDelta.x / sizeDelta.y;
                childRect.sizeDelta = new Vector2(parentHeight * aspectRatio, parentHeight);
                float newX = (parentRect.width * i) / player.MaxCommandInHand + parentRect.xMin + childRect.rect.width / 2;
                childRect.anchoredPosition = new Vector2(newX, 0);

            }
        }
    }
}