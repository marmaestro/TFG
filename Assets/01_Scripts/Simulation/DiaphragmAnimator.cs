using TFG.ExtensionMethods;
using UnityEngine;

namespace TFG.Simulation
{
    public partial class DiaphragmAnimator : MonoBehaviour
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

        public static void OpenAnimation()
        {
            _diaphragm.SetActive(true);
            _animator.SetTrigger(Open);
        }
        
        public static void OpenFinished()
        {
            CameraSimulator.SimulationStart();
        }

        public static void CloseAnimation()
        {
            _animator.SetTrigger(Close);
        }
        
        public static void CloseFinished()
        {
            _diaphragm.SetActive(false);
            CameraSimulator.SimulationEnd();
        }
    }
}