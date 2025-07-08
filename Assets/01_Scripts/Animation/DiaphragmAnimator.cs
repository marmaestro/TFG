using TFG.Simulation;
using UnityEngine;

namespace TFG.Animation
{
    public class DiaphragmAnimator : MonoBehaviour
    {
        private static Animator animator;
        private static GameObject diaphragm; 
        
        private static readonly int OpenTrigger = Animator.StringToHash("openDiaphragm");
        private static readonly int CloseTrigger = Animator.StringToHash("closeDiaphragm");

        

        public void Awake()
        {
            animator = gameObject.GetComponentInChildren<Animator>(true);
            diaphragm = transform.GetChild(0).gameObject;
        }

        public static void OpenAnimation()
        {
            diaphragm.SetActive(true);
            animator.SetTrigger(OpenTrigger);
        }
        
        public static void OpenFinished()
        {
            CameraSimulator.SimulationStart();
        }

        public static void CloseAnimation()
        {
            animator.SetTrigger(CloseTrigger);
        }
        
        public static void CloseFinished()
        {
            diaphragm.SetActive(false);
            CameraSimulator.SimulationEnd();
        }
    }
}