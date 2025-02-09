using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private static GameObject _pauseCanvas;

    public void Awake()
    {
        _pauseCanvas = gameObject;
    }

    public void Start()
    {
        PauseMenu(true);
    }

    public static void PauseMenu(bool paused)
    {
        _pauseCanvas.SetActive(paused);
        if (!paused)
        {
            SceneManager.UnloadSceneAsync("Scenes/Pause");
            GameManager.PauseGame(false);
        }
    }
}