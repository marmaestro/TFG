using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using SM = UnityEngine.SceneManagement.SceneManager;

namespace TFG.SceneManagement
{
    public static class SceneManager
    {
        public static string GetActiveScene() => SM.GetActiveScene().name;
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
    }
}