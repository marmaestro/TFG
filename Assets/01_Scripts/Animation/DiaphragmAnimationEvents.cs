using UnityEngine;

namespace TFG.Simulation
{
    public class DiaphragmAnimationEvents : MonoBehaviour
    {
        public void OpenFinished(int n)
        {DiaphragmAnimator.OpenFinished();
        }

        public void CloseFinished(int n)
        {
            DiaphragmAnimator.CloseFinished();
        }
    }
}