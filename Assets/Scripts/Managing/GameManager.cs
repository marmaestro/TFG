using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    protected static ISaveable[] gameData;

    public const float CameraAngle = 315; //-45
    public const float CameraSensitivity = 2.25f;
    public const float CameraRotationThreshold = 0.05f;
    public const int RenderScale = 5;

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