using UnityEngine;
using UnityEngine.SceneManagement;

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
                SceneManager.UnloadSceneAsync("Scenes/Pause");
                Game.PauseGame(false);
            }
        }
    }
}