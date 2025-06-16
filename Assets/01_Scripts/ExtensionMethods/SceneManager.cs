using System.Linq;
using UnityEngine.SceneManagement;
using SM = UnityEngine.SceneManagement.SceneManager;

namespace TFG.ExtensionMethods
{
    public static class SceneManager
    {
        public static void LoadScene(string sceneName) => SM.LoadScene(sceneName, LoadSceneMode.Single);
        public static void AddScene(string sceneName) => SM.LoadScene(sceneName, LoadSceneMode.Additive);

        public static void AddMultipleScenes(string[] sceneNames)
        {
            foreach (string sceneName in sceneNames) AddScene(sceneName);
        }

        public static void UnloadScene(string sceneName) => SM.UnloadSceneAsync(sceneName);

        public static void UnloadMultipleScenes(string[] sceneNames)
        {
            foreach (string sceneName in sceneNames.Reverse()) UnloadScene(sceneName);
        }

        private static bool LoadedScene(string sceneName) => SM.GetSceneByName(sceneName).isLoaded;

        public static void LocationSceneLoaded()
        {
            UnloadNavigation();

            int amount = Game.player.steps <= 0 ? 1 : Game.NextLocations().Length;
            string navScene = $"Navigation_{amount}";

            AddScene(navScene);
        }

        private static void UnloadNavigation()
        {
            if (LoadedScene("Navigation_1"))
                UnloadScene("Navigation_1");
            else if (LoadedScene("Navigation_2"))
                UnloadScene("Navigation_2");
            else if (LoadedScene("Navigation_3"))
                UnloadScene("Navigation_3");
        }
    }
}