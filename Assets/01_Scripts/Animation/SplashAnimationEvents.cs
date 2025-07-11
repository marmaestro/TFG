using TFG.ExtensionMethods;
using UnityEngine;

namespace TFG.Animation
{
    public class SplashAnimationEvents : MonoBehaviour
    {
        public void Awake()
        {
            Cursor.visible = false;
        }
    
        public void OnSplashFinished()
        {
            SceneManager.LoadScene("Persistent");
        }
    }
}