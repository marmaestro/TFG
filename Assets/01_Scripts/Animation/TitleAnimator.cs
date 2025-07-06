using TFG.InputSystem;
using UnityEngine;

namespace TFG.Animation
{
    public class TitleAnimator : MonoBehaviour
    {
        private static Animator animator;
        
        private static readonly int ShowPopup = Animator.StringToHash("showPopup");
        private static readonly int HidePopup = Animator.StringToHash("hidePopup");
    
        public void Awake()
        {
            animator = gameObject.GetComponentInChildren<Animator>(true);
            
            if (Game.FirstPlay) animator.Play("TitleAnimation");
        }

        public static void OnTitleAnimated()
        {
            Game.FirstPlay = false;
            GameActions.EnableInputSystem(true);
            GameActions.SwitchActionMap(ActionMaps.UI);
        }

        public static void ShowTitlePopup()
        {
            animator.SetTrigger(ShowPopup);
        }

        public static void HideTitlePopup()
        {
            animator.SetTrigger(HidePopup);
        }
    }
}