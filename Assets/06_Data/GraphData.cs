using System;
using System.Diagnostics;
using System.Linq;
using TFG.ExtensionMethods;
using TFG.Navigation;
using UnityEngine;
using Console = TFG.ExtensionMethods.Console;

namespace TFG.Data
{
    [Serializable]
    [CreateAssetMenu(fileName = "Graph", menuName = "SIL/Graphs/Graph")]
    public class GraphData : ScriptableObject
    {
        [SerializeField] public NodeData[] nodes;
        
        #region Graph Visualization
        #if UNITY_EDITOR
        [Conditional("UNITY_EDITOR")]
        public void Show()
        {
            string data = "\n";
            
            foreach (NodeData node in nodes)
            {
                data += $"┗ {node.SceneName}:";
                data = node.Edges.Aggregate(data, (s, n) => $"{s} {n}");
                data += "\n";
            }
            
            Console.Log(ConCat.Graph, data);
        }
        #endif
        #endregion
    }
}