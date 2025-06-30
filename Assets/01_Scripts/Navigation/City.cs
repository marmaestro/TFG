using System;
using TFG.Data;

namespace TFG.NavigationSystem
{
    [Serializable]
    public class City
    {
        private Graph graph;
        public string[] sceneNames => graph.NodeNames;
        public string[] sceneTags => graph.NodeTags;
        public bool[] visitedLocations;

        public City(GraphData data)
        {
            graph = new Graph(data);
            visitedLocations = new bool[graph.NodeCount];
        }

        public int[] VisitableLocations()
        {
            return graph.AvailableNodes();
        }
    }
}