using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TFG.UIElements.Buttons.TabSystems
{
    [RequireComponent(typeof(Image))]
    public class TabButtonBottom : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] public bool rightTab;
        [SerializeField] public TabGroupBottom tabGroup;

        private CanvasGroup _self;
        internal Image Background;

        public void Start()
        {
            Background = transform.GetComponent<Image>();
            _self = GetComponent<CanvasGroup>();
            Show(rightTab);
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

        public void Show(bool show)
        {
            _self.alpha = show ? 1 : 0;
            _self.interactable = show;
            _self.blocksRaycasts = show;
        }
    }
}