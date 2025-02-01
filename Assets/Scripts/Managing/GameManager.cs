using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    protected static ISaveable[] gameData;
    
    public static readonly InputAction MoveAction = InputSystem.actions.FindAction("Movement");
    public static readonly InputAction LookAction = InputSystem.actions.FindAction("Look");

    public const float CameraAngle = 315; //-45
    public const float CameraSensitivity = 2.25f;

    public static bool StartGameRequest()
    {
        return !FileManager.LoadFromFile("saveData", out string _);
    }
    
    public static void StartGame()
    {
        SceneManager.LoadScene("Start");
    }
    
    public static void LoadGame()
    {
        SaveDataManager.LoadJsonData(gameData);
    }

    public static void SaveGame()
    {
        SaveDataManager.SaveJsonData(gameData);
    }

    public static void PauseGame(bool paused)
    {
        Time.timeScale = paused ? 1 : 0;
    }
}