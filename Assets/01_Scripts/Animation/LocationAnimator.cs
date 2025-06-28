using UnityEngine;

namespace TFG.Animation
{
    public class LocationAnimator : MonoBehaviour
    {
        private static Animator animator;

        public void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public static void TriggerAnimation(string trigger)
        {
            animator.SetTrigger(trigger);
        }
    }
}