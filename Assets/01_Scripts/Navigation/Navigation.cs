using System;
using TFG.ExtensionMethods;
using UnityEngine;
using static TFG.Player;
using Console = TFG.ExtensionMethods.Console;

namespace TFG.Navigation
{
    public class Navigation
    {
        private readonly Game game;
        public string CurrentLocation => game.city.scenes[location];

        public Navigation(Game game)
        {
            this.game = game;
        }

        private string[] NextLocations()
        {
            int[] locationIDs = game.city.VisitableSpots();
            string[] nextLocations = new string[locationIDs.Length];
            
            for (int i = 0; i < locationIDs.Length; i++)
                nextLocations[i] = game.city.scenes[locationIDs[i]];
            
            return nextLocations;
        }
        
        public void Visit(int uncodedDestination)
        {
            string[] nextLocations = NextLocations();
            string destination = nextLocations[uncodedDestination];
         
            #if DEBUG
            Console.Log(ConsoleCategories.SceneManagement,
                $"Leaving scene {game.city.scenes[location]} to {destination}");
            #endif
            
            SceneManager.AddScene(destination);
            SceneManager.UnloadScene(game.city.scenes[location]);

            int id = Array.IndexOf(game.city.scenes, destination);
            game.city.visitedLocations[id] = true;
            location = id;
        }
    }
}