using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TabButtonC : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public bool rightTab; 
    [SerializeField] public TabGroup tabGroup;
    internal Image Background;

    private CanvasGroup _self;

    public void Start()
    {
        Background = transform.GetComponent<Image>();
        _self = GetComponent<CanvasGroup>();
        Show(rightTab);
    }

    public void Show(bool show)
    {
        _self.alpha = show ? 1 : 0;
        _self.interactable = show;
        _self.blocksRaycasts = show;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit();
    }
}
