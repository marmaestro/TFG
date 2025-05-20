using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static TFG.Game;

namespace TFG.UIElements.Buttons
{
    public class MainMenuButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] internal string target;
        [SerializeField] internal Popup popup;

        public void OnPointerClick(PointerEventData eventData)
        {
            switch (target)
            {
                case "Start":
                    if (!StartGameRequest())
                        popup.Show();
                    else StartGame();
                    break;

                case "StartOverride": StartGame(); break;

                case "Continue": LoadGame(); break;

                case "ClosePopup": popup.Hide(); break;

                case "Settings":
                case "Credits":
                    SceneManager.LoadScene(target, LoadSceneMode.Additive); break;

                case "Close": Application.Quit(); break;
            }
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