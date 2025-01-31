using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static GameManager;

public class PauseMenuButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] internal string target;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(target);
        switch (target)
        {
            case "Pause": PauseGame(true); break;
            
            case "Continue": PauseGame(false); break;
                
            case "Settings":
            case "MainMenu":
                SceneManager.LoadScene(target); break;
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