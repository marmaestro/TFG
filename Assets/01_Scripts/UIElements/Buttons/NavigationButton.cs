using TFG.ExtensionMethods;
using UnityEngine;
using UnityEngine.EventSystems;
using static TFG.ExtensionMethods.UIExtensions;

namespace TFG.UIElements.Buttons
{
    public class NavigationButton : MonoBehaviour, ICustomButton
    {
        [SerializeField] internal int target;

        public void OnPointerClick(PointerEventData eventData)
        {
            NavigationMenu(target);
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