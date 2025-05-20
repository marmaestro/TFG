using UnityEngine;

namespace TFG.Managing.UISystems
{
    public class DiaphragmAnimation : MonoBehaviour
    {
        private static Animator _animator;

        public void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Start()
        {
            OpenDiaphragmAnimation();
        }

        public static void OpenDiaphragmAnimation()
        {
            _animator.Play("In");
        }

        public static void CloseDiaphragmAnimation()
        {
            _animator.Play("Out");
        }
    }
}
