using TFG.InputSystem;
using TFG.ExtensionMethods;
using UnityEngine;
using static TFG.Animation.DiaphragmAnimator;

namespace TFG.Simulation
{
    [RequireComponent(typeof(Camera))]
    public class CameraSimulator : MonoBehaviour
    {
        [SerializeField] internal GameObject textHolder;
        internal static CameraSimulatorExtension reflectingExtension;
        internal new static Camera camera;
        private static readonly Vector2 bounds = new(635, 420);

        private static Texture2D shot;
        private static readonly string[] simulationScenes = { "CameraInterface" };

        #region Unity Events
        public void Awake()
        {
            camera = GetComponent<Camera>();
            reflectingExtension = GetComponents<CameraSimulatorExtension>()[0];
        }

        public void LateUpdate()
        {
            camera.Render();
        }
        #endregion

        #region Behaviour Methods
        public static void MovePointer(Vector2 delta)
        {
            float rawX = camera.transform.position.x + delta.x;
            float rawY = camera.transform.position.y + delta.y;
            
            float clampedX = Mathf.Clamp(rawX, - bounds.x , bounds.x);
            float clampedY = Mathf.Clamp(rawY, - bounds.y, bounds.y);
            
            camera.transform.position = new Vector3(clampedX, clampedY, camera.transform.position.z);
        }
        #endregion

        #region Simulation Handling
        public static void OpenCamera()
        {
            PlayerActions.PauseInputSystem();
            SimulationStartAnimation();
        }

        public static void OpenCameraReflecting()
        {
            OpenCamera();
            reflectingExtension.enabled = true;
        }

        public static void CloseCamera()
        {
            reflectingExtension.enabled = false;
            PlayerActions.PauseInputSystem();
            SimulationEndAnimation();
        }

        private static void SimulationStartAnimation()
        {
            OpenAnimation();
            SceneManager.AddMultipleScenes(simulationScenes);
        }

        public static void SimulationStart()
        {
            PlayerActions.PauseInputSystem();
            PlayerActions.SwitchActionMap(Game.navigation.Visited ? ActionMaps.Camera : ActionMaps.Reflecting);
        }

        private static void SimulationEndAnimation()
        {
            CloseAnimation();
        }

        internal static void SimulationEnd()
        {
            SceneManager.UnloadMultipleScenes(simulationScenes);
            PlayerActions.PauseInputSystem();
            PlayerActions.SwitchActionMap(ActionMaps.World);
        }
        #endregion
    }
}