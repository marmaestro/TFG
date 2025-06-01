using TFG.ExtensionMethods;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TFG.UIElements.Buttons
{
    public class NavigationButton : CustomButton
    {
        [SerializeField] internal int target;
        
        public override void OnPointerClick(PointerEventData eventData) => MenuExtensions.NavigationMenu(target);
    }
}