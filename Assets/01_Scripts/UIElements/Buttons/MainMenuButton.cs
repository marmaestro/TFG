using TFG.ExtensionMethods;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TFG.UIElements.Buttons
{
    public class MainMenuButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] internal string target;
        [SerializeField] internal Popup popup;

        public void OnPointerClick(PointerEventData eventData)
        {
            MenuExtensions.MainMenu(target, popup);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            gameObject.transform.localScale += Vector3.one * 0.2f;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            gameObject.transform.localScale -= Vector3.one * 0.2f;
        }
    }
}