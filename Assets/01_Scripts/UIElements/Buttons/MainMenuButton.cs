using UnityEngine;
using UnityEngine.EventSystems;
using static TFG.UIElements.Buttons.ButtonConnector;

namespace TFG.UIElements.Buttons
{
    public class MainMenuButton : MonoBehaviour, ICustomButton
    {
        [SerializeField] internal string target;

        public void OnPointerClick(PointerEventData eventData)
        {
            MainMenu(target);
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