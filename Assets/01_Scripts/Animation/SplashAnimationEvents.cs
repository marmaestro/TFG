using TFG.ExtensionMethods;
using TFG.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

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
