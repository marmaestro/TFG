using TFG.ExtensionMethods;
using TFG.InputSystem;
using TFG.NavigationSystem;
using TFG.DataManagement;
using TFG.DialogueSystem;
using UnityEngine;

namespace TFG
{
    public class Game : MonoBehaviour, ISaveableData
    {
        [SerializeField] public City city;
        
        public static string CurrentLocation => "TEST_FACILITY"; //City?.CurrentLocation;
        
        internal static Player player;
        
        private static Navigation navigation;
        private static StoryHandler storyHandler;
        
        private static ISaveableData[] gameData;

        private readonly TextAsset gameNarrative = Resources.Load<TextAsset>("main");

        public void Awake()
        {
            SceneManager.AddScene("MainMenu");
            navigation = new Navigation(this);
            storyHandler = new StoryHandler(gameNarrative);
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

        public void PopulateSaveData(SaveSystem data)
        {
            data.gameData.city = city;
            data.gameData.player = player;
            data.gameData.story = storyHandler.SaveStory();
        }
        
        public void LoadFromSaveData(SaveSystem data)
        {
            city = data.gameData.city;
            player = data.gameData.player;
            storyHandler.LoadStory(data.gameData.story);
        }
        
        public static void Visit(int destination)
        {
            player.Move();
            navigation.Visit(destination);
        }

        public static void GoHome()
        {
            navigation.GoHome();
            player.Reset();
        }
        
        public static string[] NextLocations() => navigation.NextLocations();

        public static void LoadMainMenu()
        {
            SceneManager.AddScene("MainMenu");
            SceneManager.UnloadScene("Title");
        }
    }
}