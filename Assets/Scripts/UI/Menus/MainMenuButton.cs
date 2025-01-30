using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static GameManager;
using static PopupManager;

public class MainMenuButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] internal string target;
    [SerializeField] internal ProgressOverlayManager progressOverlay;
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
            
            case "Continue": ContinueGame(); break;
            
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
        if (target == "Continue") progressOverlay.Show();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (target != "Continue")
            gameObject.transform.localScale -= Vector3.one * 0.2f;
    }
}
