using TFG.ExtensionMethods;
using UnityEngine;

public class SplashAnimator : MonoBehaviour
{
    public void OnSplashFinished()
    {
        SceneManager.LoadScene("Persistent");
    }
}
