using TFG.Data;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace TFG.UIElements.Editor
{
    [CustomEditor(typeof(GraphData))]
    public class GraphInterface : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GraphData graph = (GraphData)target;
            if (GUILayout.Button("Show graph"))
            {
                graph.Show();
            }
        }
    }
}
#endif