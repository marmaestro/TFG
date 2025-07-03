using TFG.InputSystem;
using TFG.ExtensionMethods;
using UnityEngine;
using static TFG.Animation.DiaphragmAnimator;

namespace TFG.Simulation
{
    [RequireComponent(typeof(Camera))]
    public partial class CameraSimulator : MonoBehaviour
    {
        [SerializeField] private GameObject textHolder;
        
        private static Game game;
        private new static Camera camera;
        private static Texture2D shot;
        private static bool reflecting;
        
        private static readonly Vector2 bounds = new(635, 420);
        private static readonly string[] simulationScenes = { "CameraInterface" };

        #region Unity Events
        public void Awake()
        {
            camera = GetComponent<Camera>();
        }

        public void LateUpdate()
        {
            camera.Render();
        }
        #endregion

        #region Behaviour Methods
        public static void OpenCamera()
        {
            reflecting = !Game.navigation.Visited;
            PlayerActions.PauseInputSystem();
            
            SimulationStartAnimation();
        }

        public static void CloseCamera()
        {
            PlayerActions.PauseInputSystem();
            SimulationEndAnimation();
        }
        
        public static void MovePointer(Vector2 delta)
        {
            float rawX = camera.transform.position.x + delta.x;
            float rawY = camera.transform.position.y + delta.y;
            
            float clampedX = Mathf.Clamp(rawX, - bounds.x , bounds.x);
            float clampedY = Mathf.Clamp(rawY, - bounds.y, bounds.y);
            
            camera.transform.position = new Vector3(clampedX, clampedY, camera.transform.position.z);
            
            if (reflecting) CastRay();
        }
        #endregion

        #region Basic Simulation Handling
        private static void SimulationStartAnimation()
        {
            OpenAnimation();
            SceneManager.AddMultipleScenes(simulationScenes);
        }

        public static void SimulationStart()
        {
            if (reflecting) LoadReflecting();
            PlayerActions.PauseInputSystem();
            PlayerActions.SwitchActionMap(reflecting ? ActionMaps.Reflecting : ActionMaps.Camera);
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