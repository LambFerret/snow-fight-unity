using script.soldier;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace script.component
{
    public class HoverTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public GameObject tooltipPanel; // Assign your tooltip panel in the inspector
        public Soldier soldier;

        // Run when the mouse cursor enters the object's UI element
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (soldier == null) return;
            tooltipPanel.SetActive(true);
            var tooltipText = soldier.id + "\n" + soldier.rangeX + " / " + soldier.rangeY + "\n"
                              + "speed : " + soldier.speed + "\n" + "runAway : " + soldier.runAwayProbability + "\n" +
                              soldier.rank + "\n" + soldier.branch + "\n" + soldier.empowerLevel;
            tooltipPanel.GetComponentInChildren<Text>().text = tooltipText;
        }

        // Run when the mouse cursor exits the object's UI element
        public void OnPointerExit(PointerEventData eventData)
        {
            tooltipPanel.SetActive(false);
        }
    }
}