using EasyTextEffects;
using FMODUnity;
using TMPro;
using UnityEngine;

namespace TFG.Narrative
{
    public class Rewriter : MonoBehaviour
    {
        private TMP_Text textMeshPro;
        private TextEffect textEffect;
        private StudioEventEmitter fmodEvent;

        #region Unity Events
        public void Awake()
        {
            textMeshPro = gameObject.GetComponentInChildren<TMP_Text>();
            textEffect = gameObject.GetComponentInChildren<TextEffect>();
            fmodEvent = gameObject.GetComponentInChildren<StudioEventEmitter>();
        }
        #endregion

        #region Write Methods
        public void Rewrite(string text)
        {
            if (!textMeshPro.text.Equals(text))
            {
                ClearSound();
                textMeshPro.text = text;
                textMeshPro.ForceMeshUpdate();
                textEffect.StartManualEffects();
                fmodEvent.Play();
            }
        }

        public void Clear()
        {
            textMeshPro.text = "";
            textMeshPro.enabled = false;
            fmodEvent.Stop();
        }
        #endregion
        
        #region Animation Methods

        public void ClearSound()
        {
            RuntimeManager.GetBus("bus:/UI").stopAllEvents(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
        #endregion
    }
}