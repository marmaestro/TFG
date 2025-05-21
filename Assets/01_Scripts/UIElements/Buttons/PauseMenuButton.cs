using UnityEngine;
using UnityEngine.EventSystems;
using static TFG.ExtensionMethods.MenuExtensions;

namespace TFG.UIElements.Buttons
{
    public class PauseMenuButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] internal string target;

        public void OnPointerClick(PointerEventData eventData)
        {
            PauseMenu(target);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            gameObject.transform.localScale += Vector3.one * 0.1f;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            gameObject.transform.localScale -= Vector3.one * 0.1f;
        }
    }
}