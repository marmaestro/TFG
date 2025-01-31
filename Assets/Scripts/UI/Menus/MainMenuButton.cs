using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static GameManager;

public class MainMenuButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] internal string target;
    [SerializeField] internal PopupManager popup;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(target);
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
                SceneManager.LoadScene(target); break;
            
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
