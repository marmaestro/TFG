using TFG.InputSystem;
using UnityEditor;
using UnityEngine;

namespace TFG.UIElements.Editor
{
    [CustomEditor(typeof(PlayerActions))]
    public class InputSystemInterface : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            PlayerActions actions = (PlayerActions)target;
            if (GUILayout.Button("Show current map"))
            {
                actions.Show();
            }
        }
    }
}