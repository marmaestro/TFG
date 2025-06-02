using System;
using System.Collections.Generic;
using System.Linq;
using TFG.ExtensionMethods;
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

        public Graph(TextAsset file)
        {
            home = 0;
            current = 0;
            
            /*nodes = new List<Node>();
            FileManager.LoadGraphFromFile(file,  out GraphData data);
            for (int id = 0; id < data.ints.Length; id++)
            {
                nodes.Add(new Node(id, data.ints[id]));
            }*/
            
            #if DEBUG
            Show();
            #endif
        }

        public void Show()
        {
            string data = "Graph:\n";
            /*for (int i = 0; i < nodes.Count; i++)
            {
                data += $"{i} >";
                data = nodes[i].Edges.Aggregate(data, (s, n) => $"{s} {n}");
                data += "\n";
            }*/
            foreach (Node node in nodes)
            {
                data += $"{node.id} >";
                data = node.Edges.Aggregate(data, (s, n) => $"{s} {n}");
                data += "\n";
            }
            Console.Log(ConsoleCategories.Graph, data);
        }

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