using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TabButtonC : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public bool rightTab; 
    [SerializeField] public TabGroup tabGroup;
    internal Image Background;

    public void Start()
    {
        Background = transform.GetComponent<Image>();
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
