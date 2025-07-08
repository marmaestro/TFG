using System.Linq;
using EasyTextEffects.Editor.MyBoxCopy.Extensions;
using UnityEngine.SceneManagement;
using SM = UnityEngine.SceneManagement.SceneManager;

namespace TFG.ExtensionMethods
{
    public static class SceneManager
    {
        public static int currentNavigationSceneID => LoadedScene("Navigation_1") ? 1 : LoadedScene("Navigation_2") ? 2 : LoadedScene("Navigation_3") ? 3 : 0;
        
        #region Loading Extensions
        public static void LoadScene(string sceneName) => SM.LoadScene(sceneName, LoadSceneMode.Single);
        public static void AddScene(string sceneName) => SM.LoadScene(sceneName, LoadSceneMode.Additive);
        
        public static void AddSceneWithCheck(string sceneName)
        {
            if (!LoadedScene(sceneName))
                AddScene(sceneName);
        }

        public static void AddMultipleScenes(string[] sceneNames)
        {
            sceneNames.ForEach(AddScene);
        }
        #endregion

        #region Unloading Extensions
        public static void UnloadScene(string sceneName)
        {
            try
            {
                SM.UnloadSceneAsync(sceneName);
            }
            catch
            {
                #if DEBUG
                Console.LogWarning(ConCat.SceneManagement, $"Scene {sceneName} cannot be unloaded.");
                #endif
            }
        }

        public static void UnloadMultipleScenes(string[] sceneNames)
        {
            sceneNames.Reverse().ForEach(UnloadScene);
        }
        
        public static void ClearScenes()
        {
            for (int i = 0; i <= SM.loadedSceneCount; i++)
            {
                Scene scene = SM.GetSceneAt(i);
                if (!scene.name.Equals("Persistent"))
                    SM.UnloadSceneAsync(scene.name);
            }
        }

        private static void UnloadNavigationScene()
        {
            UnloadScene($"Navigation_{currentNavigationSceneID}");
        }
        #endregion

        #region Auxiliar Extensions
        private static bool LoadedScene(string sceneName) => SM.GetSceneByName(sceneName).isLoaded;

        public static void OnLocationSceneLoaded()
        {
            UnloadNavigationScene();

            int amount = Game.player.steps <= 0 ? 1 : Game.NextLocations().Length;
            string navScene = $"Navigation_{amount}";

            if (Game.player.steps >= 0)
                AddScene(navScene);
        }
        #endregion
    }
}