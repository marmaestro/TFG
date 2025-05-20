using TFG.Managing.UISystems;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace TFG.UI.Menus
{
    public class PauseMenuButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] internal string target;
    
        public void OnPointerClick(PointerEventData eventData)
        {
            switch (target)
            {
                case "Continue": PauseManager.PauseMenu(false); break;
                
                case "Settings":
                case "MainMenu":
                    SceneManager.LoadScene(target, LoadSceneMode.Additive); break;
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