using EasyTextEffects;
using TMPro;
using UnityEngine;

namespace TFG.Narrative
{
    public class Rewriter : MonoBehaviour
    {
        internal static TMP_Text textMeshPro;
        internal static TextEffect textEffect;

        internal static void Rewrite(string text)
        {
            textMeshPro.text = text;
            textEffect.StartManualEffects();
        }
    }
}