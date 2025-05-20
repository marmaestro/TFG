using UnityEngine;

namespace TFG.UI.Menus
{
    public class PopupManager : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
