using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    protected static ISaveable[] gameData;
    
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