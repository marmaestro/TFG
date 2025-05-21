using TFG.ExtensionMethods;
using UnityEngine;

namespace TFG.Simulation
{
    public class DiaphragmAnimator : MonoBehaviour
    {
        private static Animator _animator;
        private static GameObject _diaphragm; 
        private static readonly int Open = Animator.StringToHash("openDiaphragm");
        private static readonly int Close = Animator.StringToHash("closeDiaphragm");

        public void Awake()
        {
            // TODO : Move the animator into the camera interface
            _animator = gameObject.GetComponentInChildren<Animator>(true);
            _diaphragm = transform.GetChild(0).gameObject;
        }

        public static void OpenDiaphragmAnimation()
        {
            _diaphragm.SetActive(true);
            _animator.SetTrigger(Open);
#if DEBUG
            Console.Log(ConsoleCategories.Animation, "Opening diaphragm");
#endif
        }

        public static void CloseDiaphragmAnimation()
        {
            _animator.SetTrigger(Close);
            _diaphragm.SetActive(false);
#if DEBUG
            Console.Log(ConsoleCategories.Animation, "Closing diaphragm");
#endif
        }
    }
}