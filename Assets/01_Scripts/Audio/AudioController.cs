using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace TFG.Audio
{
    public class AudioController : MonoBehaviour
    {
        private const string bankPath = "bank:/";
        private const string musicPath = "event:/Music Events/";
        
        private EventInstance eventEmitter;
        private StudioBankLoader bankLoader;

        public void Awake()
        {
            bankLoader = GetComponents<StudioBankLoader>()[1];
            LoadBank(AudioBanks.Intro);
        }

        public void LoadBank(string bankName)
        {
            StopMusic();

            bankLoader.Unload();
            bankLoader.Banks = new List<string> { bankPath + bankName };
            bankLoader.Load();
            
            PlayMusic(bankName);
        }
        
        private void PlayMusic(string trackName)
        {
            eventEmitter = RuntimeManager.CreateInstance(musicPath + trackName);
            eventEmitter.start();
        }

        private void StopMusic()
        {
            if (eventEmitter.isValid())
            {
                eventEmitter.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                eventEmitter.release();
            }
        }
    }
}