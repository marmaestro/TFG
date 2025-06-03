using UnityEngine;
using SM = UnityEngine.SceneManagement.SceneManager;

namespace TFG.ExtensionMethods
{
    public class NavigationLoader : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod]
        private static void SceneLoaded()
        {
            SM.sceneLoaded += SceneManager.SceneLoaded;
        }
    }
}
