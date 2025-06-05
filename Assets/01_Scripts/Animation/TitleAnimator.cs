using UnityEngine;

namespace TFG.Animation
{
    public class TitleAnimator : MonoBehaviour
    {
        private static Animator _animator;
        private static readonly int ShowPopup = Animator.StringToHash("showPopup");
        private static readonly int HidePopup = Animator.StringToHash("hidePopup");
    
        public void Awake()
        {
            _animator = gameObject.GetComponentInChildren<Animator>(true);
        }

        public static void ShowTitlePopup()
        {
            _animator.SetTrigger(ShowPopup);
        }

        public static void HideTitlePopup()
        {
            _animator.SetTrigger(HidePopup);
        }
    }
}