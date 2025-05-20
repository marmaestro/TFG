using TFG.InputSystem;
using TFG.SaveSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TFG
{
    public class Game : MonoBehaviour
    {
        private static ISaveableData[] gameData;
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
            SceneManager.LoadScene("Persistent", LoadSceneMode.Additive);
            PauseGame(false);
            SceneManager.LoadScene("Start", LoadSceneMode.Additive);
        }

        public static void LoadGame()
        {
            DataManager.LoadJsonData(gameData);
        }

        public static void SaveGame()
        {
            DataManager.SaveJsonData(gameData);
        }

        public static void PauseGame(bool paused)
        {
            Time.timeScale = paused ? 0 : 1;
            Actions.SwitchActionMap(paused);

            SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
        }
    }
}