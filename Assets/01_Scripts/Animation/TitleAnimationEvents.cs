using UnityEngine;

namespace TFG.Animation
{
    public class TitleAnimationEvents : MonoBehaviour
    {
        public void TitleAnimationFinished(int n)
        {
            TitleAnimator.OnTitleAnimated();
        }
    }
}