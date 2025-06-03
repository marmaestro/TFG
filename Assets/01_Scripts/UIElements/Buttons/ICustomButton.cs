using UnityEngine;
using UnityEngine.EventSystems;

namespace TFG.UIElements.Buttons
{
    public interface ICustomButton : IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public virtual void OnPointerClick(PointerEventData eventData) { }
        public virtual void OnPointerEnter(PointerEventData eventData) { }
        public virtual void OnPointerExit(PointerEventData eventData) { }

    }
}