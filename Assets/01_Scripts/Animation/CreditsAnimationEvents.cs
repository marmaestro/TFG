using TFG.ExtensionMethods;
using UnityEngine;

public class CreditsAnimationEvents : MonoBehaviour
{
    public void Awake()
    {
        Cursor.visible = false;
    }
    
    public void OnCreditsFinished()
    {
        SceneManager.LoadScene("Persistent");
    }
}
