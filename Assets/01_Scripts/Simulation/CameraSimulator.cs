using System;
using TFG.InputSystem;
using TFG.SaveSystem;
using TFG.ExtensionMethods;
using UnityEngine;
using static TFG.Simulation.DiaphragmAnimator;
using Console = TFG.ExtensionMethods.Console;

namespace TFG.Simulation
{
    public class CameraSimulator : MonoBehaviour
    {
        private static Camera _camera;
        private static Transform _target;

        private static readonly string SavedImagesPath = ""; //Path.Combine(Application.dataPath, "Resources/Images/Saved");
        private static readonly string RenderTargetPath = "Images/Renderers/FM2Output";
        private static readonly string[] SimulationScenes = { "CameraInterface" };

        private static RenderTexture RenderTarget;

        private static Texture2D _shot;

        // Unity events
        public void Awake()
        {
            RenderTarget = Resources.Load(RenderTargetPath) as RenderTexture;
        }
        
        public void Start()
        {
            _camera = GetComponent<Camera>();
            _target = GameObject.FindGameObjectWithTag("PointerTarget").transform;
            
            #if DEBUG
            Console.Log(ConsoleCategories.Debug, $"_camera is {_camera.name}");
            Console.Log(ConsoleCategories.Debug, $"_target is {_target.name}");
            #endif
        }

        public void LateUpdate()
        {
            _camera.Render();
        }

        // Behaviour
        public static void MoveCamera(Vector2 delta)
        {
            _target.position = new Vector3(delta.x, delta.y, _target.transform.position.z);
        }

        public static void TakePicture()
        {
            // Call the camera to render
            _camera.Render();

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
        }

        // Simulation
        public static void OpenCamera()
        {
            // Open picture interface/camera simulation
            SimulationStartAnimation();
        }

        public static void CloseCamera()
        {
            // Close picture interface/camera simulation
            SimulationEndAnimation();
        }

        private static void SimulationStartAnimation()
        {
            OpenAnimation();
            SceneManager.AddMultipleScenes(SimulationScenes);
        }

        public static void SimulationStart()
        {
            // Switch active action map
            Actions.SwitchActionMap(true);
        }

        private static void SimulationEndAnimation()
        {
            CloseAnimation();
        }

        internal static void SimulationEnd()
        {
            SceneManager.UnloadMultipleScenes(SimulationScenes);
            // Switch active action map
            Actions.SwitchActionMap();
        }
    }
}