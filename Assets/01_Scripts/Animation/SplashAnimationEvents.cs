using TFG.ExtensionMethods;
using UnityEngine;

public class SplashAnimationEvents : MonoBehaviour
{
    public void OnSplashFinished()
    {
        SceneManager.LoadScene("Persistent");
    }
}
