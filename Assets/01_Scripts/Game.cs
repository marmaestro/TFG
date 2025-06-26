using TFG.ExtensionMethods;
using TFG.InputSystem;
using TFG.NavigationSystem;
using TFG.DataManagement;
using TFG.Narrative;
using UnityEngine;

namespace TFG
{
    public class Game : MonoBehaviour, ISaveableData
    {
        [SerializeField] public City city;
        
        public static string CurrentLocation => "TEST_FACILITY"; //City?.CurrentLocation;
        
        internal static Player player;
        internal static Navigation navigation;
        private static StoryHandler storyHandler;
        private static ISaveableData[] gameData;

        internal static bool FirstPlay = true; 

        private TextAsset gameNarrative;

        public void Awake()
        {
            gameNarrative = Resources.Load<TextAsset>("main");
            SceneManager.AddScene("MainMenu");
            
            navigation = new Navigation(this);
            storyHandler = new StoryHandler(gameNarrative);
        }

        public static bool ExistingSaveFile() => FileManager.Exists("SaveData");

        public static void MainMenu()
        {
            SceneManager.ClearScenes();
            SceneManager.AddScene("MainMenu");
            PlayerActions.SwitchActionMap(ActionMaps.UI);
        }

        private static void StartGame()
        {
            PlayerActions.SwitchActionMap(ActionMaps.World);
            PauseGame(false);
            GoHome(false);
        }

        public static void StartNewGame()
        {
            player = new Player();
            StartGame();
        }

        public static void LoadGame()
        {
            if (ExistingSaveFile())
            {
                DataManager.LoadJsonData(gameData);
                StartGame();
            }
            
            else StartNewGame();
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
            if (paused)
            {
                Time.timeScale = 0;
                SceneManager.AddSceneWithCheck("PauseMenu");
                PlayerActions.SwitchActionMap(ActionMaps.UI);
            }

            else
            {
                Time.timeScale = 1;
                SceneManager.UnloadScene("PauseMenu");
                PlayerActions.SwitchActionMap(ActionMaps.World);
            }
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

        public static void GoHome(bool  endOfDay = true)
        {
            if (endOfDay) PlayerActions.SwitchActionMap(ActionMaps.UI);
            
            navigation.GoHome(endOfDay);
            player.Reset();
        }
        
        public static string[] NextLocations() => navigation.NextLocations();
    }
}