using TFG.Animation;
using TFG.ExtensionMethods;

namespace TFG.UIElements.Buttons
{
    public static class ButtonConnector
    {
        public static void MainMenu(string target)
        {
            switch (target)
            {
                case "Start" when Game.ExistingSaveFile(): TitleAnimator.ShowTitlePopup(); break;
                
                case "Start":
                case "StartOverride": Game.StartNewGame(); break;
                
                case "Continue": Game.LoadGame(); break;
                
                case "ClosePopup": TitleAnimator.HideTitlePopup(); break;
                
                case "Close": Game.QuitGame(); break;
                
                default: SceneManager.AddScene(target); break;
            }
        }

        public static void PauseMenu(string target)
        {
            switch (target)
            {
                case "Continue": Game.PauseGame(false); break;

                case "Tutorial": SceneManager.AddScene("PauseMenuTutorial"); break;
                
                case "UnloadTutorial": SceneManager.UnloadScene("PauseMenuTutorial"); break;
                
                case "Quit": Game.QuitGame(); break; 
                
                case "SaveGame": Game.SaveGame(); break;
            }
        }

        public static void NavigationMenu(int target)
        {
            if (Game.player.steps <= 0)
                Game.GoHome();
            Game.Visit(target);
        }

        public static void CreditsMenu()
        {
            Game.MainMenu();
        } 
    }
}