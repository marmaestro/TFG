using TFG.ExtensionMethods;
using static TFG.Player;
using static TFG.Navigation.City;

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

        public string[] NextLocations()
        {
            int[] locationIDs = game.city.VisitableSpots();
            string[] nextLocations = new string[locationIDs.Length];
            
            for (int i = 0; i < locationIDs.Length; i++)
                nextLocations[i] = game.city.scenes[locationIDs[i]];
            
            return nextLocations;
        }
        
        public void Visit(int destination)
        {
            SceneManager.AddScene(game.city.scenes[destination]);
            SceneManager.UnloadScene(game.city.scenes[location]);
            
            game.city.visitedLocations[destination] = true;
            location = destination;
        }
    }
}