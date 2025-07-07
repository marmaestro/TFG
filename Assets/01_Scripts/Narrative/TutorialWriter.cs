using TFG.ExtensionMethods;
using UnityEngine.EventSystems;
using UnityEngine;

namespace TFG.Narrative
{
    public class TutorialWriter : MonoBehaviour, IPointerClickHandler
    {
        private const string section = "tutorial";
        
        private void Awake()
        {
            StoryHandler.StartStorySection(section);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (TextBridge.NextLine()) return;
            
            SceneManager.UnloadScene("Tutorial");
            Game.navigation.GoHome(false);
        }
    }
}