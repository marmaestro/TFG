using TFG.InputSystem;
using UnityEditor;
using UnityEngine;

namespace TFG.UIElements.Editor
{
    [CustomEditor(typeof(GameActions))]
    public class InputSystemInterface : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            GameActions actions = (GameActions)target;
            if (GUILayout.Button("Show current map"))
            {
                actions.Show();
            }
        }
    }
}