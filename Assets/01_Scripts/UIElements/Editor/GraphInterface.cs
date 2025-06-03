using TFG.Graphs;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace TFG.UIElements.Editor
{
    [CustomEditor(typeof(Graph))]
    public class GraphInterface : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            Graph graph = (Graph)target;
            if (GUILayout.Button("Show graph"))
            {
                graph.Show();
            }
        }
    }
}
#endif