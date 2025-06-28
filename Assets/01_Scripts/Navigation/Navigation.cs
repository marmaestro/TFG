using System;
using TFG.ExtensionMethods;
using static TFG.Game;
using Console = TFG.ExtensionMethods.Console;

namespace TFG.NavigationSystem
{
    public class Navigation
    {
        private readonly Game game;

        public bool Visited => game.City.VisitedLocations[player.location];
        private string currentLocationName => game.City.SceneNames[player.location];
        
        private const string Home = "0 Home";

        #region Constructor
        public Navigation(Game game)
        {
            this.game = game;
        }
        #endregion

        #region Navigation Methods
        public string[] NextLocations()
        {
            int[] locationIndexes = game.City.VisitableLocations();
            string[] nextLocations = new string[locationIndexes.Length];

            for (int i = 0; i < locationIndexes.Length; i++)
                nextLocations[i] = game.City.SceneNames[locationIndexes[i]];

            return nextLocations;
        }
        
        public void Visit(int uncodedDestination)
        {
            string[] nextLocations = NextLocations();
            string destination = nextLocations[uncodedDestination];
            
            #if DEBUG
            Console.Log(ConsoleCategories.SceneManagement, $"Leaving scene {currentLocationName} to {destination}");
            #endif
            
            SceneManager.UnloadScene(currentLocationName);
            SceneManager.AddScene(destination);

            int id = Array.IndexOf(game.City.SceneNames, destination);
            game.City.VisitedLocations[player.location] = true;
            player.location = id;
        }

        public void GoHome(bool endOfDay)
        {
            SceneManager.AddScene(Home);
            player.location = 0;
            
            if (endOfDay)
            {
                SceneManager.UnloadScene(currentLocationName);
                SceneManager.UnloadNavigationScene();
                SceneManager.AddScene("Diary");
                
                // TODO : Create diary logic and narrative
            }
            
            else SceneManager.UnloadScene("MainMenu");
        }
        #endregion
    }
}