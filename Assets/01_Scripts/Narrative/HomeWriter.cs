using TFG.InputSystem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TFG.Narrative
{
    public class HomeWriter : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Canvas UICanvas;
        private const string section = "home";
        private Game game;
        
        private void Start()
        {
            game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();

            if (!game.city.visitedLocations[0])
            {
                game.city.visitedLocations[0] = true;
                StoryHandler.StartStorySection(section);
            }

            else
            {
                UICanvas.enabled = false;
                enabled = false;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (UICanvas.enabled)
            {
                if (TextBridge.NextLine()) return;

                UICanvas.enabled = false;
                GameActions.SwitchActionMap(ActionMaps.World);
            }
        }
    }
}