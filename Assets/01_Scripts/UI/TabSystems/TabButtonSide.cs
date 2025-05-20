using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TFG.UI.TabSystems
{
    [RequireComponent(typeof(Image))]
    public class TabButtonSide : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] public TabGroupSide tabGroup;
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
}