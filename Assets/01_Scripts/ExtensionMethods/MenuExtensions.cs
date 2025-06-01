using TFG.UIElements;
using UnityEngine;
using static TFG.Game;

namespace TFG.ExtensionMethods
{
    public static class MenuExtensions
    {
        public static void MainMenu(string target, Popup popup)
        {
            switch (target)
            {
                case "Start" when ExistingSaveFile(): popup.Show(); break;
                
                case "Start":
                case "StartOverride": StartNewGame(); break;
                
                case "Continue": LoadGame(); break;
                
                case "ClosePopup": popup.Hide(); break;
                
                case "Close": QuitGame(); break;
                
                default: SceneManager.AddScene(target); break;
            }
        }

        public static void PauseMenu(string target)
        {
            switch (target)
            {
                case "Continue": UIElements.PauseMenu.PauseGame(false); break;

                case "Settings":
                case "MainMenu": SceneManager.AddScene(target); break;
                
                case "SaveGame": SaveGame(); break;
                
                case "ExitGame": QuitGame(); break;
            }
        }
    }
}