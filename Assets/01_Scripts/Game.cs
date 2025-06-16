using TFG.ExtensionMethods;
using TFG.InputSystem;
using TFG.Navigation;
using TFG.DataManagement;
using UnityEngine;

namespace TFG
{
    public class Game : MonoBehaviour, ISaveableData
    {
        private static ISaveableData[] gameData;
        [SerializeField] public City city;
        internal static Player player;
        private static Navigation.Navigation navigation;
        public static string CurrentLocation => "TEST_FACILITY"; //City?.CurrentLocation;

        public void Awake()
        {
            SceneManager.AddScene("MainMenu");
            navigation = new Navigation.Navigation(this);
        }

        public static bool ExistingSaveFile() => FileManager.Exists("SaveData");

        public static void MainMenu()
        {
            SceneManager.UnloadScene("Credits");
        }

        private static void StartGame()
        {
            PauseGame(false);
            SceneManager.UnloadScene("MainMenu");
            SceneManager.AddScene("Start");
        }

        public static void StartNewGame()
        {
            player = new Player();
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
            Actions.PauseInputSystem();

            SceneManager.LoadScene("Pause");
        }

        public void PopulateSaveData(SaveSystem saveData)
        {
            saveData.playerData.city = city;
            saveData.playerData.player = player;
        }
        
        public void LoadFromSaveData(SaveSystem saveData)
        {
            city = saveData.playerData.city;
            player = saveData.playerData.player;
        }
        
        public static void Visit(int destination)
        {
            navigation.Visit(destination);
            player.Visit(destination);
        }

        public static void GoHome()
        {
            player.GoHome();
        }
        
        public static string[] NextLocations() => navigation.NextLocations();

        public static void LoadMainMenu()
        {
            SceneManager.AddScene("MainMenu");
            SceneManager.UnloadScene("Title");
        }
    }
}