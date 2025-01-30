using UnityEngine;
using UnityEngine.EventSystems;

public class ProgressOverlayManager : MonoBehaviour, IPointerClickHandler
{
    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Hide(); // TODO : "Continue" behaviour: continue/close buttons, load data, etc. 
    }
}
