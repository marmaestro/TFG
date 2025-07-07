using System.Collections;
using EasyTextEffects;
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
        internal void Rewrite(string text, bool centered = false)
        {
            if (!textMeshPro.text.Equals(text))
            {
                textMeshPro.text = text;
                textEffect.StartManualEffects();

                if (centered) textMeshPro.alignment = TextAlignmentOptions.Center;
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
        
        public void Clear()
        {
            textMeshPro.text = "";
            textMeshPro.enabled = false;
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