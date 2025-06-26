using EasyTextEffects;
using TFG.InputSystem;
using TFG.ExtensionMethods;
using TFG.Narrative;
using TMPro;
using UnityEngine;
using static TFG.Animation.DiaphragmAnimator;

namespace TFG.Simulation
{
    [RequireComponent(typeof(Camera))]
    public class CameraSimulator : MonoBehaviour
    {
        [SerializeField] internal GameObject textHolder;
        internal new static Camera camera;
        private static readonly Vector2 bounds = new(635, 420); // (635/2, 420/2) // (317.5f, 210f)

        //private static RenderTexture renderTarget;
        private static Texture2D shot;

        //private const string SavedImagesPath = "";
        //private const string RenderTargetPath = "Images/Renderers/FM2Output";
        private static readonly string[] simulationScenes = { "CameraInterface" };

        #region Unity Events
        public void Awake()
        {
            //renderTarget = Resources.Load(RenderTargetPath) as RenderTexture;

            Rewriter.textMeshPro = textHolder.GetComponent<TextMeshPro>();
            Rewriter.textEffect = textHolder.GetComponent<TextEffect>();

            camera = GetComponent<Camera>();
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
        
        /*public static void TakePicture()
        {
            // Call the camera to render
            camera.Render();

            // Set up the Texture2D
            _shot = new Texture2D(RenderTarget.width, RenderTarget.height, TextureFormat.RGB24, false);

            // Copy the rendered texture
            RenderTexture.active = RenderTarget;
            _shot.ReadPixels(new Rect(0, 0, RenderTarget.width, RenderTarget.height), 0, 0);
            _shot.Apply();

            // Write (save) the rendered texture
            FileManager.WriteToPictureFile(SavedImagesPath, EncodePictureName(), _shot.EncodeToPNG());

            _shot = null;
        }

        private static string EncodePictureName()
        {
            // The file name is 'CurrenScene_Date_Time.png'
            return $"{Game.CurrentLocation}_{DateTime.Now:yyMMdd}_{DateTime.Now:HHmmss}.png";
        }*/
        #endregion

        #region Simulation Handling
        public static void OpenCamera()
        {
            PlayerActions.PauseInputSystem();
            SimulationStartAnimation();
        }

        public static void CloseCamera()
        {
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
        }

        private static void SimulationEndAnimation()
        {
            CloseAnimation();
        }

        internal static void SimulationEnd()
        {
            SceneManager.UnloadMultipleScenes(simulationScenes);
            PlayerActions.PauseInputSystem();
        }
        #endregion
    }
}