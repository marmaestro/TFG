using UnityEngine;
using UnityEngine.EventSystems;
using static TFG.ExtensionMethods.MenuExtensions;

namespace TFG.UIElements.Buttons
{
    public class PauseMenuButton : CustomButton
    {
        [SerializeField] internal string target;
        public override void OnPointerClick(PointerEventData eventData) => PauseMenu(target);
        public override void OnPointerEnter(PointerEventData eventData)
        {
            gameObject.transform.localScale += Vector3.one * 0.1f;
        }
        public override void OnPointerExit(PointerEventData eventData)
        {
            gameObject.transform.localScale -= Vector3.one * 0.1f;
        }
    }
}