using EasyTextEffects;
using TMPro;
using UnityEngine;

namespace TFG.DialogueSystem
{
    public class Rewriter : MonoBehaviour
    {
        [SerializeField] private TMP_Text textMeshPro;
        [SerializeField] private TextEffect textEffect;

        public void Rewrite(string text)
        {
            textMeshPro.text = text;
            textEffect.StartManualEffects();
        }
    }
}