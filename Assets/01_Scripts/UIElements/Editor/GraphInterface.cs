using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace TFG.UIElements.Editor
{
    [CustomEditor(typeof(Navigation.Graph))]
    public class GraphInterface : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            Navigation.Graph graph = (Navigation.Graph)target;
            if (GUILayout.Button("Show graph"))
            {
                graph.Show();
            }
        }
    }
}
#endif