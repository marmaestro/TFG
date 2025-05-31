using TFG.ExtensionMethods;
using TFG.Graphs;
using TFG.InputSystem;
using TFG.SaveSystem;
using UnityEngine;

namespace TFG
{
    public class Game : MonoBehaviour, ISaveableData
    {
        private static ISaveableData[] gameData;
        public static City City;
        public static Player Player;
        public static string CurrentLocation => "TEST_FACILITY"; //City?.CurrentLocation;

        /*public void Awake()
        {
            SceneManager.LoadScene("MainMenu");
        }*/

        public static bool ExistingSaveFile() => FileManager.Exists("SaveData");

        private static void StartGame()
        {
            PauseGame(false);
            SceneManager.LoadScene("Start");
        }

        public static void StartNewGame()
        {
            City = Resources.Load<City>($"Assets/{nameof(City)}");
            Player = new Player();
            StartGame();
        }

        public static void LoadGame()
        {
            DataManager.LoadJsonData(gameData);
            StartGame();
        }

        public static void SaveGame()
        {
            DataManager.SaveJsonData(gameData);
        }

        public static void QuitGame()
        {
            SaveGame();
            Application.Quit();
        }

        public static void PauseGame(bool paused)
        {
            Time.timeScale = paused ? 0 : 1;
            Actions.SwitchActionMap(paused);

            SceneManager.LoadScene("Pause");
        }

        public void PopulateSaveData(SaveSystem.SaveSystem saveData)
        {
            saveData.playerData.city = City;
            saveData.playerData.player = Player;
        }
        public void LoadFromSaveData(SaveSystem.SaveSystem saveData)
        {
            City = saveData.playerData.city;
            Player = saveData.playerData.player;
        }
    }
}