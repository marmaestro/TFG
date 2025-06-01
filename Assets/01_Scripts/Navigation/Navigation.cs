using TFG.ExtensionMethods;
using static TFG.Player;
using static TFG.Navigation.City;

namespace TFG.Navigation
{
    public static class Navigation
    {
        public static string CurrentLocation => scenes[location];

        public static string[] NextLocations()
        {
            int[] locationIDs = city.VisitableNodes();
            string[] nextLocations = new string[locationIDs.Length];
            
            for (int i = 0; i < locationIDs.Length; i++)
                nextLocations[i] = scenes[locationIDs[i]];
            
            return nextLocations;
        }
        
        public static void Visit(int destination)
        {
            SceneManager.AddScene(scenes[destination]);
            SceneManager.UnloadScene(scenes[location]);
            
            visitedLocations[destination] = true;
            location = destination;
        }
    }
}