using TFG.Audio;
using TFG.ExtensionMethods;
using UnityEngine.EventSystems;
using UnityEngine;

namespace TFG.Narrative
{
    public class TutorialWriter : MonoBehaviour, IPointerClickHandler
    {
        private const string section = "tutorial";
        
        private void Start()
        {
            StoryHandler.StartStorySection(section);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (TextBridge.NextLine()) return;
            
            SceneManager.UnloadScene("Tutorial");
            Game.audioController.LoadBank(AudioBanks.Game);
            NavigationSystem.Navigation.GoHome(false);
            NavigationAudioController.PlaySound();
        }
    }
}