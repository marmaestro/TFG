using TFG.ExtensionMethods;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TFG.UIElements.Buttons
{
    public class NavigationButton : MonoBehaviour, ICustomButton
    {
        [SerializeField] internal int target;

        public void OnPointerClick(PointerEventData eventData)
        {
            Console.Log(ConsoleCategories.Debug, "This is from the button.");
            UserInterfaceExtensions.NavigationMenu(target);
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