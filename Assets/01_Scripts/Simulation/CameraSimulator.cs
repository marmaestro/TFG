using System;
using EasyTextEffects;
using TFG.InputSystem;
using TFG.DataManagement;
using TFG.DialogueSystem;
using TFG.ExtensionMethods;
using TMPro;
using UnityEngine;
using static TFG.Animation.DiaphragmAnimator;

namespace TFG.Simulation
{
    [RequireComponent(typeof(Camera))]
    public class CameraSimulator : MonoBehaviour
    {
        [SerializeField] private GameObject textHolder;
        private new static Camera camera;

        private const string SavedImagesPath = ""; //Path.Combine(Application.dataPath, "Resources/Images/Saved");
        private const string RenderTargetPath = "Images/Renderers/FM2Output";
        private static readonly string[] SimulationScenes = { "CameraInterface" };

        private static RenderTexture RenderTarget;

        private static Texture2D _shot;

        #region Unity Events
        public void Awake()
        {
            RenderTarget = Resources.Load(RenderTargetPath) as RenderTexture;
            
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
            camera.transform.position = new Vector3(delta.x, delta.y, camera.transform.position.z);
        }

        public static void TakePicture()
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
        }
        #endregion

        #region Simulation
        public static void OpenCamera()
        {
            // Open picture interface/camera simulation
            SimulationStartAnimation();
        }

        public static void Close()
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
            PlayerActions.SwitchActionMap(ActionMaps.Camera);
        }

        private static void SimulationEndAnimation()
        {
            CloseAnimation();
        }

        internal static void SimulationEnd()
        {
            SceneManager.UnloadMultipleScenes(SimulationScenes);
            PlayerActions.SwitchActionMap(ActionMaps.World);
        }
        #endregion
    }
}