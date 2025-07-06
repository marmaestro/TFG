using TFG.ExtensionMethods;
using UnityEngine;
using static TFG.Game;

namespace TFG.InputSystem
{
    public static class InputDecoding
    {
        public static void ParseDelta(Vector2 delta)
        {
            switch (SceneManager.currentNavigationSceneID)
            {
                case 1:
                    if (delta.y < 0)
                        Visit(player.steps.Equals(0) ? -1 : 0);
                    break;
                
                case 2: // ReSharper disable once ConvertIfStatementToSwitchStatement
                    if (delta.x < 0)
                        Visit(0);
                    else if (delta.x > 0)
                        Visit(1);
                    break;
                
                case 3:
                    if (delta.x < 0)
                        Visit(0);
                    else if (delta.y < 0)
                        Visit(1);
                    else if (delta.x > 0)
                        Visit(2);
                    break;
                
                default:
                    Visit(-1);
                    break;
            }
        }
    }
}