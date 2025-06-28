using System.Collections;
using EasyTextEffects;
using TFG.Animation;
using TMPro;
using UnityEngine;

namespace TFG.Narrative
{
    public class Rewriter : MonoBehaviour
    {
        private TMP_Text textMeshPro;
        private TextEffect textEffect;

        #region Unity Events
        public void Awake()
        {
            textMeshPro = gameObject.GetComponentInChildren<TMP_Text>();
            textEffect = gameObject.GetComponentInChildren<TextEffect>();
        }
        #endregion

        #region Write Methods
        internal void Rewrite(string text)
        {
            if (!textMeshPro.text.Equals(text))
            {
                textMeshPro.text = text;
                textEffect.StartManualEffects();
            }
        }

        internal void Rewrite(string[] textLList)
        {
            foreach (string text in textLList)
            {
                textMeshPro.text = text;
                textEffect.StartManualEffects();
                StartCoroutine(WaitForEffect());
            }
        }
        #endregion

        #region Auxiliary Methods
        private IEnumerator WaitForEffect()
        {
            yield return textEffect.FindManualEffect("").onEffectCompleted;
        }
        #endregion
    }
}