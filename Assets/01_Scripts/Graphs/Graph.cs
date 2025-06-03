using System;
using System.Collections.Generic;
using System.Linq;
using TFG.ExtensionMethods;
using UnityEditor;
using UnityEngine;
using Console = TFG.ExtensionMethods.Console;

namespace TFG.Graphs
{
    [Serializable]
    [CreateAssetMenu(fileName = "Graph", menuName = "SIL/Graphs/Graph")]
    public class Graph : ScriptableObject
    {
        [SerializeField] private List<Node> nodes;

        private readonly int home;
        private readonly int current;
        internal string[] nodeNames => nodes.Select(n => n.name).ToArray();

        #if UNITY_EDITOR
        public void Show()
        {
            string data = "Graph:\n";
            
            foreach (Node node in nodes)
            {
                data += $"{node.name} >";
                data = node.Edges.Aggregate(data, (s, n) => $"{s} {n}");
                data += "\n";
            }
            Console.Log(ConsoleCategories.Graph, data);
        }
        #endif

        public int NodeCount => nodes.Count;

        public int[] VisitableNodes() => nodes[current].Edges;
        
        public int Distance(int origin, int target)
        {
            bool[] visited = new bool[nodes.Count];
            int[] distance = new int[nodes.Count];
            Queue<int> queue = new();
            
            distance[origin] = 0;
            visited[origin] = true;
            queue.Enqueue(origin);

            while (queue.Any())
            {
                int node = queue.Dequeue();
                if (node == target) break;

                foreach (int edge in nodes[node].Edges)
                {
                    if (!visited[edge])
                    {
                        distance[edge] = distance[node] + 1;
                        visited[edge] = true;
                        queue.Enqueue(edge);
                    }
                }
            }
            
            return distance[target];
        }
    }
}