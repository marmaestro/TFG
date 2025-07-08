using TFG.Audio;
using TFG.Data;
using TFG.ExtensionMethods;
using TFG.InputSystem;
using TFG.NavigationSystem;
using TFG.DataManagement;
using TFG.Narrative;
using UnityEngine;
using UnityEngine.Serialization;

namespace TFG
{
    public class Game : MonoBehaviour, ISaveableData
    {
        [SerializeField] private GraphData gameGraphData; 
        [FormerlySerializedAs("City")] public City city;
        
        internal static Player player;
        internal static NavigationSystem.Navigation navigation;
        private static StoryHandler storyHandler;
        private static ISaveableData[] gameData;
        internal static AudioController audioController;

        internal static bool FirstPlay = true; 

        private TextAsset gameNarrative;

        public void Awake()
        {
            city = new City(gameGraphData);
            
            gameNarrative = Resources.Load<TextAsset>("main");
            navigation = new NavigationSystem.Navigation(this);
            storyHandler = new StoryHandler(gameNarrative);
            audioController = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>();
            
            SceneManager.AddScene("MainMenu");
            GameActions.CursorToggle(true);
        }

        public static bool ExistingSaveFile() => FileManager.Exists("SaveData");

        public static void MainMenu()
        {
            SceneManager.ClearScenes();
            SceneManager.AddScene("MainMenu");
            GameActions.SwitchActionMap(ActionMaps.UI);
        }

        private static void StartGame()
        {
            StartTutorial();
        }

        private static void StartTutorial()
        {
            SceneManager.UnloadScene("MainMenu");
            SceneManager.AddScene("Tutorial");
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
                GameActions.SwitchActionMap(ActionMaps.UI);
            }

            else
            {
                Time.timeScale = 1;
                SceneManager.UnloadScene("PauseMenu");
                GameActions.SwitchActionMap(ActionMaps.World);
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
            NavigationAudioController.PlaySound();
            player.Move();
            navigation.Visit(destination);
        }

        public static void GoHome(bool  endOfDay = true)
        {
            if (endOfDay)
            {
                GameActions.SwitchActionMap(ActionMaps.UI);
                audioController.LoadBank(AudioBanks.Outro);
            }

            else
            {
                GameActions.SwitchActionMap(ActionMaps.World);
                audioController.LoadBank(AudioBanks.Game);
            }
            
            NavigationSystem.Navigation.GoHome(endOfDay);
        }
        
        public static string[] NextLocations() => navigation.NextLocations();
    }
}