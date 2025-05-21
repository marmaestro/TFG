using TFG.ExtensionMethods;
using TFG.InputSystem;
using TFG.SaveSystem;
using UnityEngine;

namespace TFG
{
    public class Game : MonoBehaviour
    {
        private static ISaveableData[] gameData;
        public static string fm2data;

        public void Awake()
        {
            // Load camera data
            //const string cameraDataPath = "09_Data/FM2";
            //FileManager.LoadFromFile(cameraDataPath, out fm2data);
        }

        public static bool StartGameRequest()
        {
            return !FileManager.LoadFromFile("saveData", out string _);
        }

        public static void StartGame()
        {
            PauseGame(false);
            SceneManager.LoadScene("Start");
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

            SceneManager.LoadScene("Pause");
        }
    }
}