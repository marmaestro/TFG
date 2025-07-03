using System;
using TFG.ExtensionMethods;
using static TFG.Game;
using Console = TFG.ExtensionMethods.Console;

namespace TFG.NavigationSystem
{
    public class Navigation
    {
        private readonly Game game;

        public bool Visited => game.city.visitedLocations[player.location];
        public string currentLocationName => game.city.sceneNames[player.location];
        
        public const string Home = "0 Home";

        #region Constructor
        public Navigation(Game game)
        {
            this.game = game;
        }
        #endregion

        #region Navigation Methods
        public string[] NextLocations()
        {
            int[] locationIndexes = game.city.VisitableLocations();
            string[] nextLocations = new string[locationIndexes.Length];

            for (int i = 0; i < locationIndexes.Length; i++)
                nextLocations[i] = game.city.sceneNames[locationIndexes[i]];

            return nextLocations;
        }
        
        public void Visit(int uncodedDestination)
        {
            if (uncodedDestination.Equals(-1))
            {
                Game.GoHome();
                return;
            }
            
            string[] nextLocations = NextLocations();
            string destination = nextLocations[uncodedDestination];
            
            #if DEBUG
            Console.Log(ConCat.SceneManagement, $"Leaving scene {currentLocationName} to {destination}");
            #endif
            
            SceneManager.UnloadScene(currentLocationName);
            SceneManager.AddScene(destination);

            int id = Array.IndexOf(game.city.sceneNames, destination);
            game.city.visitedLocations[player.location] = true;
            player.location = id;
        }

        public void GoHome(bool endOfDay)
        {
            SceneManager.AddScene(Home);
            
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