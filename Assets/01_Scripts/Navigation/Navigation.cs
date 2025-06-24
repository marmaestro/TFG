using System;
using TFG.ExtensionMethods;
using static TFG.Player;
using Console = TFG.ExtensionMethods.Console;

namespace TFG.NavigationSystem
{
    public class Navigation
    {
        private readonly Game game;
        private string currentLocation => game.city.scenes[locationID];
        private const string Home = "Home";

        public Navigation(Game game)
        {
            this.game = game;
        }

        public string[] NextLocations()
        {
            int[] locationIndexes = game.city.VisitableSpots();
            string[] nextLocations = new string[locationIndexes.Length];

            for (int i = 0; i < locationIndexes.Length; i++)
                nextLocations[i] = game.city.scenes[locationIndexes[i]];

            return nextLocations;
        }
        
        public void Visit(int uncodedDestination)
        {
            string[] nextLocations = NextLocations();
            string destination = nextLocations[uncodedDestination];
            
            #if DEBUG
            Console.Log(ConsoleCategories.SceneManagement, $"Leaving scene {currentLocation} to {destination}");
            #endif
            
            SceneManager.UnloadScene(currentLocation);
            SceneManager.AddScene(destination);

            int id = Array.IndexOf(game.city.scenes, destination);
            game.city.visitedLocations[id] = true;
            locationID = id;
        }

        public void GoHome()
        {
            SceneManager.AddScene(Home);
            SceneManager.UnloadScene(currentLocation);
        }
    }
}