using UnityEngine;
using UnityEngine.SceneManagement;

namespace TFG.CameraSimulation
{
    public class Cameras : MonoBehaviour
    {
        public static void OpenCamera()
        {
            // Open picture interface / camera simulation
            SimulationStart();
            // Switch active action map
            GameActions.SwitchActionMap(true);
        }

        public static void CloseCamera()
        {
            // Close picture interface / camera simulation
            SimulationEnd();
            // Switch active action map
            GameActions.SwitchActionMap(false);
        }

        private static void SimulationStart()
        {
            SceneManager.LoadScene("Scenes/CameraInterface", LoadSceneMode.Additive);
        }

        private static void SimulationEnd()
        {
            SceneManager.UnloadSceneAsync("Scenes/CameraInterface");
        }
    }
}
