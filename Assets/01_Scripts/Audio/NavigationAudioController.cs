using FMODUnity;
using UnityEngine;

namespace TFG.Audio
{
    public class NavigationAudioController : MonoBehaviour
    {
        private static StudioEventEmitter emitter;

        public void Awake()
        {
            emitter = GetComponent<StudioEventEmitter>();
        }

        public static void PlaySound()
        {
            emitter.Play();
        }
    }
}