using TFG.ExtensionMethods;
using UnityEngine;

namespace TFG.UIElements
{
    public class PauseMenu : MonoBehaviour
    {
        private static GameObject _pauseCanvas;

        public void Awake()
        {
            _pauseCanvas = gameObject;
        }

        public void Start()
        {
            PauseGame(true);
        }

        public static void PauseGame(bool paused)
        {
            _pauseCanvas.SetActive(paused);
            if (!paused)
            {
                SceneManager.UnloadScene("PauseMenu");
                Game.PauseGame(false);
            }
        }
    }
}