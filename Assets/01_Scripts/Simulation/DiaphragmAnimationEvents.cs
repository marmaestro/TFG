using TFG.ExtensionMethods;
using UnityEngine;

namespace TFG.Simulation
{
    public class DiaphragmAnimationEvents : MonoBehaviour
    {
        public void OpenFinished(int n)
        {
            #if DEBUG
            Console.Log(ConsoleCategories.Animation, "Opening diaphragm");
            #endif
            
            DiaphragmAnimator.OpenFinished();
        }

        public void CloseFinished(int n)
        {
            #if DEBUG
            Console.Log(ConsoleCategories.Animation, "Closing diaphragm");
            #endif
            
            DiaphragmAnimator.CloseFinished();
        }
    }
}