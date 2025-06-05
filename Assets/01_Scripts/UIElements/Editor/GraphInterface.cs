using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace TFG.UIElements.Editor
{
    [CustomEditor(typeof(Graph.Graph))]
    public class GraphInterface : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            Graph.Graph graph = (Graph.Graph)target;
            if (GUILayout.Button("Show graph"))
            {
                graph.Show();
            }
        }
    }
}
#endif