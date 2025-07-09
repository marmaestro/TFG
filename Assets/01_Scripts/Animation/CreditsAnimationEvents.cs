using TFG.ExtensionMethods;
using UnityEngine;

namespace TFG.Animation
{
    public class CreditsAnimationEvents : MonoBehaviour
    {
        public void Awake()
        {
            Cursor.visible = false;
        }
    
        public void OnCreditsFinished()
        {
            FMODUnity.RuntimeManager.GetBus("bus:/Music").stopAllEvents(FMOD.Studio.STOP_MODE.IMMEDIATE);
            SceneManager.LoadScene("Persistent");
        }
    }
}