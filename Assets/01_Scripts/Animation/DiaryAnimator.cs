using EasyTextEffects;
using TMPro;
using UnityEngine;

namespace TFG.Animation
{
    public class DiaryAnimator : MonoBehaviour
    {
        private TextEffect leftTextEffect;
        private TextEffect rightTextEffect;

        public void Init(TMP_Text leftText, TMP_Text rightText)
        {
            leftTextEffect = leftText.GetComponent<TextEffect>();
            rightTextEffect = rightText.GetComponent<TextEffect>();
        }

        public void AnimateLeft()
        {
            leftTextEffect.StartManualEffects();
        }

        public void AnimateRight()
        {
            rightTextEffect.StartManualEffects();
        }
    }
}