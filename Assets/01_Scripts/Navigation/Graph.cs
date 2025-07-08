using System.Collections.Generic;
using System.Linq;
using EasyTextEffects.Editor.MyBoxCopy.Extensions;
using TFG.Data;
using TFG.ExtensionMethods;
using TFG.Navigation;

namespace TFG.NavigationSystem
{
    public class Graph
    {
        private readonly List<NodeData> nodes;
        
        public int NodeCount => nodes.Count;
        public string[] NodeNames => nodes.Select(n => n.SceneName).ToArray();
        public string[] NodeTags => nodes.Select(n => n.SceneTag).ToArray();

        public Graph (GraphData data)
        {
            if (!data)
            {
                Console.LogError(ConCat.Graph, "Graph not provided.");
                throw new System.Exception("Graph not provided.");
            }
            if (data.nodes.IsNullOrEmpty())
            {
                Console.LogError(ConCat.Graph, $"Graph {data.name} is empty.");
                throw new System.Exception($"Graph {data.name} empty.");
            }
            
            nodes = new List<NodeData>(data.nodes);
        }
        
        #region Graph Methods
        public int[] AvailableNodes() => nodes[Game.player.location].Edges;
        
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
                if (node.Equals(target)) break;

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
        #endregion
    }
}