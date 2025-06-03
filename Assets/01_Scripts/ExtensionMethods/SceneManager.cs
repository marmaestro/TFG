using System.Linq;
using UnityEngine.SceneManagement;
using SM = UnityEngine.SceneManagement.SceneManager;

namespace TFG.ExtensionMethods
{
    public static class SceneManager
    {
        private static string currentNavigationScene = "";
        
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

        public static void SceneLoaded(Scene scene, LoadSceneMode mode)
        {
            int amount = Game.NextLocations().Length;
            
            if (currentNavigationScene == "")
            {
                currentNavigationScene = $"Navigation_{amount}";
                AddScene(currentNavigationScene);
            }
            
            else if (!currentNavigationScene.Contains((char) amount))
            {
                UnloadScene(currentNavigationScene);
                currentNavigationScene = $"Navigation_{amount}";
                AddScene(currentNavigationScene);
            }
        }
    }
}