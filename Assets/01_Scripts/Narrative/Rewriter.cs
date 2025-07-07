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
        public void Rewrite(string text)
        {
            if (!textMeshPro.text.Equals(text))
            {
                textMeshPro.text = text;
                textMeshPro.ForceMeshUpdate();
                textEffect.StartManualEffects();
            }
        }

        public void Clear()
        {
            textMeshPro.text = "";
            textMeshPro.enabled = false;
        }
        #endregion
    }
}