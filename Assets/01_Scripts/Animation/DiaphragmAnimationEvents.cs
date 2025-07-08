using UnityEngine;

namespace TFG.Animation
{
    public class DiaphragmAnimationEvents : MonoBehaviour
    {
        public void OpenFinished(int n)
        {
            DiaphragmAnimator.OpenFinished();
        }

        public void CloseFinished(int n)
        {
            DiaphragmAnimator.CloseFinished();
        }
    }
}