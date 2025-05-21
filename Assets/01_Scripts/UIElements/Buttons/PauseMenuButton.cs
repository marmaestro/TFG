using TFG.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TFG.UIElements.Buttons
{
    public class PauseMenuButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] internal string target;

        public void OnPointerClick(PointerEventData eventData)
        {
            switch (target)
            {
                case "Continue": PauseMenu.PauseGame(false); break;

                case "Settings":
                case "MainMenu":
                    SceneManager.AddScene(target); break;
            }
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