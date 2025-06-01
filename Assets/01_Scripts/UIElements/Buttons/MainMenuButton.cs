using TFG.ExtensionMethods;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TFG.UIElements.Buttons
{
    public class MainMenuButton : CustomButton
    {
        [SerializeField] internal string target;
        [SerializeField] internal Popup popup;

        public override void OnPointerClick(PointerEventData eventData) => MenuExtensions.MainMenu(target, popup);
    }
}