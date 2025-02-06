using System;
using UnityEngine;
using UnityEngine.SceneManagement;
// ReSharper disable RedundantArgumentDefaultValue

public class CameraWorks : MonoBehaviour
{
    [SerializeField] private float sceneRotationLimit;
    
    private static OrthoCameraManager _mainCameraManager;
    private static SimulationCamerasManager _simulationCamerasManager;
    
    private static Camera _mainCamera;
    private static Camera _firstPersonCamera;
    private static Camera _simulationCamera;
    
    private static Canvas _cameraInterfaceCanvas;
    private static GameObject _pictureInterface;
    
    private static string _savedImagesPath;
    
    private static RenderTexture _renderTarget;
    private static Texture2D _lastShot;

    public void Awake()
    {
        _mainCameraManager = GetComponent<OrthoCameraManager>();
        _mainCameraManager.SceneRotationLimit = sceneRotationLimit;
        _simulationCamerasManager = GetComponent<SimulationCamerasManager>();
        
        Camera[] cameras = FindObjectsByType<Camera>(FindObjectsSortMode.None);
        _mainCamera = Array.Find(cameras, it => it.name == "Main");
        _firstPersonCamera = Array.Find(cameras, it => it.name == "FirstPerson");
        _simulationCamera = Array.Find(cameras, it => it.name == "Simulation");
        
        _mainCameraManager.MainCamera = _mainCamera;
        _simulationCamerasManager.FirstPersonCamera = _firstPersonCamera;
        _simulationCamerasManager.SimulationCamera = _simulationCamera;

        _cameraInterfaceCanvas = FindFirstObjectByType<Canvas>(FindObjectsInactive.Include);
        foreach (Transform child in _cameraInterfaceCanvas.transform)
            if (child.name == "PictureInterface")
            {
                _pictureInterface = child.gameObject;
                break;
            }

        //_renderedImagesPath = Application.dataPath + "/Images/Rendered/";
        _savedImagesPath = Application.dataPath + "/Images/Saved/";
        
        _renderTarget = _simulationCamera.targetTexture;
        _lastShot = null;
    }

    public void Start()
    {
        CloseCamera();
    }

    public static void TurnCameraAround(Vector2 lookValue)
    {
        _mainCameraManager.TurnCameraAround(lookValue);
    }
    
    public static void TurnCamera(Vector2 lookValue)
    {
        _simulationCamerasManager.Look(lookValue);
    }

    public static void TakePicture()
    {
        _simulationCamera.Render();
        _lastShot = new Texture2D(_renderTarget.width, _renderTarget.height, TextureFormat.ETC2_RGBA8, false);
        
        _pictureInterface.gameObject.SetActive(true);
        GameActions.FreezeMovement(true);
    }
    
    public static void SavePicture()
    {
        _lastShot = new Texture2D(_renderTarget.width, _renderTarget.height, TextureFormat.RGB24, false);
        RenderTexture.active = _renderTarget;
        _lastShot.ReadPixels(new Rect(0, 0, _renderTarget.width, _renderTarget.height), 0, 0);
        _lastShot.Apply();
        FileManager.WriteToPictureFile(_savedImagesPath, EncodePictureName(), _lastShot.EncodeToPNG());
        
        DiscardPicture();
    }

    private static void DiscardPicture()
    {
        _pictureInterface.gameObject.SetActive(false);
        _lastShot = null;
        
        GameActions.FreezeMovement(false);
    }

    public static void CheckExistingPicture()
    {
        if (_lastShot != null) DiscardPicture();
        else CloseCamera();
    }

    public static void OpenCamera()
    {
        DiscardPicture();
        // Switch active cameras and canvases
        _mainCamera.gameObject.SetActive(false);
        _firstPersonCamera.gameObject.SetActive(true);
        _simulationCamera.gameObject.SetActive(true);
        _cameraInterfaceCanvas.gameObject.SetActive(true);
        _simulationCamerasManager.enabled = true;
        
        GameActions.SwitchActionMap(false, true);
    }

    private static void CloseCamera()
    {
        DiscardPicture();
        // Switch active cameras and canvases
        _mainCamera.gameObject.SetActive(true);
        _firstPersonCamera.gameObject.SetActive(false);
        _simulationCamera.gameObject.SetActive(false);
        _cameraInterfaceCanvas.gameObject.SetActive(false);
        _simulationCamerasManager.enabled = false;
        
        GameActions.SwitchActionMap(false, false);
    }
    
    private static string EncodePictureName()
    {
        return $"{SceneManager.GetActiveScene().name}_{DateTime.Now:yyMMdd}_{DateTime.Now:HHmmss}.png";
    }
}
