using System;
using System.Collections.Generic;
using System.Linq;
using TFG.SaveSystem;
using UnityEngine;
using Console = TFG.ExtensionMethods.Console;

namespace TFG.Graphs
{
    [Serializable]
    public class Graph
    {
        private readonly List<Node> nodes;

        private readonly int home;
        private readonly int current; 

        public Graph(TextAsset file)
        {
            home = 0;
            current = 0;
            
            nodes = new List<Node>();
            FileManager.LoadGraphFromFile(file,  out int[][] data);
            foreach (int[] node in data)
            {
                nodes.Add(new Node(node));
            }
            #if DEBUG
            Show();
            #endif
        }

        public void Show()
        {
            string data = "Graph:\n";
            for (int i = 0; i < nodes.Count; i++)
            {
                data += $"{i} > {nodes[i].Edges}\n";
            }
            Console.Log("Graph", data);
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