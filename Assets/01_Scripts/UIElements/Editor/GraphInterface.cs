using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace TFG.UIElements.Editor
{
    [CustomEditor(typeof(NavigationSystem.Graph))]
    public class GraphInterface : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            NavigationSystem.Graph graph = (NavigationSystem.Graph)target;
            if (GUILayout.Button("Show graph"))
            {
                graph.Show();
            }
        }
    }
}
#endif