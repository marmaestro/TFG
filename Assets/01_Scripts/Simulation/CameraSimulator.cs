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

        private static readonly string SavedImagesPath = Application.dataPath + "/Resources/Images/Saved/";
        private static readonly string[] SimulationScenes = { "CameraInterface" };

        private static readonly RenderTexture RenderTarget =
            Resources.Load("Images/Renders/PolaroidOutput") as RenderTexture;

        private static Texture2D _lastShot;

        // Unity events
        public void Start()
        {
            _camera = GetComponent<Camera>();
            _target = GameObject.FindGameObjectWithTag("PointerTarget").transform;
            
            #if DEBUG
            Console.Log(ConsoleCategories.Debugging, $"_camera is {_camera.name}");
            Console.Log(ConsoleCategories.Debugging, $"_target is {_target.name}");
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
            _lastShot = new Texture2D(RenderTarget.width, RenderTarget.height, TextureFormat.RGB24, false);

            // Copy the rendered texture
            RenderTexture.active = RenderTarget;
            _lastShot.ReadPixels(new Rect(0, 0, RenderTarget.width, RenderTarget.height), 0, 0);
            _lastShot.Apply();

            // Write (save) the rendered texture
            FileManager.WriteToPictureFile(SavedImagesPath, EncodePictureName(), _lastShot.EncodeToPNG());

            _lastShot = null;
        }

        private static string EncodePictureName()
        {
            // The file name is 'CurrenScene_Date_Time.png'
            return $"{SceneManager.GetActiveScene()}_{DateTime.Now:yyMMdd}_{DateTime.Now:HHmmss}.png";
        }

        // Simulation
        public static void OpenCamera()
        {
            // Open picture interface/camera simulation
            SimulationStart();
            // Switch active action map
            Actions.SwitchActionMap(true);
        }

        public static void CloseCamera()
        {
            // Close picture interface/camera simulation
            SimulationEnd();
            // Switch active action map
            Actions.SwitchActionMap();
        }

        private static void SimulationStart()
        {
            OpenDiaphragmAnimation();
            //SceneManager.AddMultipleScenes(SimulationScenes);
        }

        private static void SimulationEnd()
        {
            CloseDiaphragmAnimation(); // TODO : This does not work
            //SceneManager.UnloadMultipleScenes(SimulationScenes);
        }
    }
}