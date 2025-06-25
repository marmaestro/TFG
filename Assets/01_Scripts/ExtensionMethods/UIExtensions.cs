using static TFG.Animation.TitleAnimator;
using static TFG.Game;

namespace TFG.ExtensionMethods
{
    public static class UIExtensions
    {
        public static void MainMenu(string target)
        {
            switch (target)
            {
                case "Start" when ExistingSaveFile(): ShowTitlePopup(); break;
                
                case "Start":
                case "StartOverride": StartNewGame(); break;
                
                case "Continue": LoadGame(); break;
                
                case "ClosePopup": HideTitlePopup(); break;
                
                case "Close": QuitGame(); break;
                
                default: SceneManager.AddScene(target); break;
            }
        }

        public static void PauseMenu(string target)
        {
            switch (target)
            {
                case "Continue": PauseGame(false); break;

                case "Settings": SceneManager.AddScene(target); break;
                
                case "MainMenu": Game.MainMenu(); break; 
                
                case "SaveGame": SaveGame(); break;
            }
        }

        public static void NavigationMenu(int target)
        {
            if (player.steps <= 0)
                GoHome();
            Visit(target);
        }

        public static void CreditsMenu()
        {
            Game.MainMenu();
        } 
    }
}