using UnityEngine;

namespace TFG.Simulation
{
    public class DiaphragmAnimator : MonoBehaviour
    {
        private static Animator _animator;
        private static readonly int Open = Animator.StringToHash("openDiaphragm");
        private static readonly int Close = Animator.StringToHash("closeDiaphragm");

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