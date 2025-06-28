using System;
using TFG.Data;
using TFG.ExtensionMethods;
using Console = TFG.ExtensionMethods.Console;

namespace TFG.NavigationSystem
{
    [Serializable]
    public class City
    {
        private Graph graph;
        public string[] SceneNames => graph.NodeNames;

        private bool[] visitedLocations;
        public bool[] VisitedLocations
        {
            get => visitedLocations;
            set => visitedLocations = value;
        }

        public City(GraphData data)
        {
            graph = new Graph(data);

            visitedLocations = new bool[graph.NodeCount];
            for (int i = 0; i < visitedLocations!.Length; i++)
                Console.LogWarning(ConsoleCategories.Debug, $"Location [{i}] visited? {visitedLocations[i]}");
        }

        public int[] VisitableLocations()
        {
            return graph.AvailableNodes();
        }
    }
}