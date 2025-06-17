using UnityEngine;
using UnityEngine.EventSystems;
using static TFG.ExtensionMethods.UIExtensions;

namespace TFG.UIElements.Buttons
{
    public class CreditsButton : MonoBehaviour, ICustomButton
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            CreditsMenu();
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            gameObject.transform.localScale += Vector3.one * 0.05f;
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            gameObject.transform.localScale -= Vector3.one * 0.05f;
        }
    }
}