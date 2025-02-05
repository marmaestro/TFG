using System;
using UnityEngine;
using UnityEngine.Windows;

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

    private static string _renderedImagesPath;
    private static string _savedImagesPath;
    
    private static RenderTexture _renderTarget;
    private static Texture2D _lastShot;
    
    internal static bool CameraIsOpen { get; private set; }
    internal static bool PictureIsShown { get; private set; }

    public void Awake()
    {
        _mainCameraManager = GetComponent<OrthoCameraManager>();
        _simulationCamerasManager = GetComponent<SimulationCamerasManager>();
        
        // TODO : CAMERAS NOT SAVED?
        Camera[] cameras = FindObjectsByType<Camera>(FindObjectsSortMode.None);
        _mainCamera = Array.Find(cameras, it => it.name == "Main");
        _firstPersonCamera = Array.Find(cameras, it => it.name == "FirstPerson");
        _simulationCamera = Array.Find(cameras, it => it.name == "Simulation");
        
        _mainCameraManager.MainCamera = _mainCamera;
        _simulationCamerasManager.FirstPersonCamera = _firstPersonCamera;
        _simulationCamerasManager.SimulationCamera = _simulationCamera;

        _cameraInterfaceCanvas = FindFirstObjectByType<Canvas>(FindObjectsInactive.Include);
        //Debug.Log(_cameraInterfaceCanvas);
        foreach (Transform child in _cameraInterfaceCanvas.transform)
            if (child.name == "PictureInterface")
            {
                _pictureInterface = child.gameObject;
                break;
            }

        _renderedImagesPath = Application.dataPath + "/Resources/Images/Rendered/";
        _savedImagesPath = Application.dataPath + "/Images/Saved/";
        
        _renderTarget = _simulationCamera.targetTexture;
        _lastShot = null;
    }

    public void Start()
    {
        CloseCamera();
    }

    public static void Look(Vector2 lookValue)
    {
        if (CameraIsOpen) _simulationCamerasManager.Look(lookValue);
        else _mainCameraManager.Look(lookValue);
    }

    public static void TakePicture()
    {
        Debug.Log("¡PATATA!");
        _simulationCamera.Render();
        _lastShot = new Texture2D(_renderTarget.width, _renderTarget.height, TextureFormat.ETC2_RGBA8, false);
        
        _pictureInterface.gameObject.SetActive(true);
        PictureIsShown = true;
        GameManager.PauseGame(true); // TODO : BLOQUEAR MOVIMIENTO
    }
    
    public static void SavePicture()
    {
        Debug.Log("¡GUARDANDO!");
        
        _lastShot.ReadPixels(new Rect(0, 0, _renderTarget.width, _renderTarget.height), 0, 0);
        _lastShot.Apply();

        byte[] bytes = _lastShot.EncodeToPNG();
        File.WriteAllBytes($"{_savedImagesPath}Saved_{DateTime.Now}.png", bytes); // TODO : CHECK TIME
        
        DiscardPicture();
    }

    public static void DiscardPicture()
    {
        Debug.Log("BORRANDO IMAGEN");
        _pictureInterface.gameObject.SetActive(false);
        _lastShot = null;
        PictureIsShown = false;
        GameManager.PauseGame(false);
    }

    public static void OpenCamera()
    {
        _mainCamera.gameObject.SetActive(false);
        _firstPersonCamera.gameObject.SetActive(true);
        _simulationCamera.gameObject.SetActive(true);
        _cameraInterfaceCanvas.gameObject.SetActive(true);
        _simulationCamerasManager.enabled = true;
        CameraIsOpen = true;
    }

    public static void CloseCamera()
    {
        DiscardPicture();
        Debug.Log("CERRANDO CÁMARA");
        _mainCamera.gameObject.SetActive(true);
        _firstPersonCamera.gameObject.SetActive(false);
        _simulationCamera.gameObject.SetActive(false);
        _cameraInterfaceCanvas.gameObject.SetActive(false);
        _simulationCamerasManager.enabled = false;
        CameraIsOpen = false;
    }
}
