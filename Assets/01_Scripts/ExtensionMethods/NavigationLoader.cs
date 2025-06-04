using UnityEngine;
using static TFG.ExtensionMethods.SceneManager;

namespace TFG.ExtensionMethods
{
    public class NavigationLoader : MonoBehaviour
    {
        private void Awake()
        {
            LocationSceneLoaded();
        }
    }
}
