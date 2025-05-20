using System;
using TFG.InputSystem;
using TFG.SaveSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using static TFG.Animation.DiaphragmAnimator;

namespace TFG.Simulation
{
    public class CameraSimulator : MonoBehaviour
    {
        private static Camera _camera;
        private static Transform _target;

        private static readonly string SavedImagesPath = Application.dataPath + "/Resources/Images/Saved/";

        private static readonly RenderTexture RenderTarget =
            Resources.Load("Images/Renders/PolaroidOutput") as RenderTexture;

        private static Texture2D _lastShot;

        // Unity events
        public void Start()
        {
            _camera = GameObject.FindGameObjectWithTag("SimulationCamera").GetComponent<Camera>();
            _target = GameObject.FindGameObjectWithTag("PointerTarget").transform;
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
            return $"{SceneManager.GetActiveScene().name}_{DateTime.Now:yyMMdd}_{DateTime.Now:HHmmss}.png";
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
            SceneManager.LoadScene("CameraInterface", LoadSceneMode.Additive);
            SceneManager.LoadScene("DiaphragmAnimation", LoadSceneMode.Additive);
            OpenDiaphragmAnimation();
        }

        private static void SimulationEnd()
        {
            CloseDiaphragmAnimation();
            SceneManager.UnloadSceneAsync("CameraInterface");
            SceneManager.UnloadSceneAsync("DiaphragmAnimation");
        }
    }
}