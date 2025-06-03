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
        private static Player player;
        private static Navigation.Navigation navigation;
        public static string CurrentLocation => "TEST_FACILITY"; //City?.CurrentLocation;

        public void Awake()
        {
            //SceneManager.LoadScene("MainMenu");
            navigation = new Navigation.Navigation(this);
        }

        public static bool ExistingSaveFile() => FileManager.Exists("SaveData");

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
            Actions.SwitchActionMap(paused);

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
        
        public static void Visit(int destination) => navigation.Visit(destination);
        public static string[] NextLocations() => navigation.NextLocations();
    }
}