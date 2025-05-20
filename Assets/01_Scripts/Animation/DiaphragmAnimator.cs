using UnityEngine;

namespace TFG.Animation
{
    public class DiaphragmAnimator : MonoBehaviour
    {
        private static Animator _animator;
        private static readonly int Open = Animator.StringToHash("Open");
        private static readonly int Close = Animator.StringToHash("Close");

        public void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public static void OpenDiaphragmAnimation()
        {
            _animator.SetTrigger(Open);
        }

        public static void CloseDiaphragmAnimation()
        {
            _animator.SetTrigger(Close);
        }
    }
}