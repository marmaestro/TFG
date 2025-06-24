using TFG.ExtensionMethods;
using UnityEngine;

namespace TFG.InputSystem
{
    public static class NavigationInput
    {
        public static void Parse(Vector2 delta)
        {
            switch (SceneManager.loadedNavigationScene)
            {
                case 1:
                    if (delta.y < 0)
                        Game.Visit(0);
                    break;
                
                case 2: // ReSharper disable once ConvertIfStatementToSwitchStatement
                    if (delta.x < 0)
                        Game.Visit(0);
                    else if (delta.x > 0)
                        Game.Visit(1);
                    break;
                
                case 3:
                    if (delta.x < 0)
                        Game.Visit(0);
                    else if (delta.y < 0)
                        Game.Visit(1);
                    else if (delta.x > 0)
                        Game.Visit(2);
                    break;
            }
        }
    }
}