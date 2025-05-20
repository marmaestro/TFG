using TFG.Managing.Save;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TFG.Managing
{
    public class GameManager : MonoBehaviour
    {
        private protected static ISaveable[] gameData;
        public static string fm2data;

        public void Awake()
        {
            // Load camera data
            const string path = "CameraSimulation/CameraData";
            FileManager.LoadFromFile(path, out fm2data);
        }

        public static bool StartGameRequest()
        {
            return !FileManager.LoadFromFile("saveData", out string _);
        }
    
        public static void StartGame()
        {
            SceneManager.LoadScene("CameraSimulation", LoadSceneMode.Additive);
            PauseGame(false);
            //SceneManager.LoadScene("Start", LoadSceneMode.Additive);
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
            Time.timeScale = paused ? 0 : 1;
            GameActions.SwitchActionMap(paused);
        
            SceneManager.LoadScene("Scenes/Pause", LoadSceneMode.Additive);
        }
    }
}