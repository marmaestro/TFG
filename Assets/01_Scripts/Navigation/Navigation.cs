using TFG.ExtensionMethods;
using static TFG.Player;
using static TFG.Navigation.City;

namespace TFG.Navigation
{
    public static class Navigation
    {
        public static string CurrentLocation => scenes[location];
        
        public static void Visit(int destination)
        {
            SceneManager.AddScene(scenes[destination]);
            SceneManager.UnloadScene(scenes[location]);
            
            visitedLocations[destination] = true;
            location = destination;
        }
    }
}