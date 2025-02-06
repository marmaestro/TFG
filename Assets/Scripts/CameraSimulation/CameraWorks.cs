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
        
        _savedImagesPath = Application.dataPath + "/Images/Saved/";
        
        _renderTarget = _simulationCamera.targetTexture;
        _lastShot = null;
    }

    public void Start()
    {
        // Cleanup scene
        CloseCamera();
    }

    public static void TurnCameraAround(Vector2 lookValue)
    {
        // Turn main (world view) camera
        _mainCameraManager.TurnCameraAround(lookValue);
    }
    
    public static void TurnCameras(Vector2 lookValue)
    {
        // Turn first-person and polaroid cameras
        _simulationCamerasManager.Look(lookValue);
    }

    public static void TakePicture()
    {
        // Call the camera to render
        _simulationCamera.Render();
        
        // Set up the Texture2D
        _lastShot = new Texture2D(_renderTarget.width, _renderTarget.height, TextureFormat.RGB24, false);
        
        // Show taken picture interface
        _pictureInterface.gameObject.SetActive(true);
        
        // Freeze camera movement (and forbid picture taking)
        GameActions.FreezeMovement(true);
    }
    
    public static void SavePicture()
    {
        // Copy the rendered texture
        RenderTexture.active = _renderTarget;
        _lastShot.ReadPixels(new Rect(0, 0, _renderTarget.width, _renderTarget.height), 0, 0);
        _lastShot.Apply();
        
        // Write (save) the rendered texture
        FileManager.WriteToPictureFile(_savedImagesPath, EncodePictureName(), _lastShot.EncodeToPNG());
        
        DiscardPicture();
    }

    private static void DiscardPicture()
    {
        // Remove picture from view
        _pictureInterface.gameObject.SetActive(false);
        _lastShot = null;
        
        // Unfreeze camera movement (and allow picture taking)
        GameActions.FreezeMovement(false);
    }

    public static void CheckExistingPicture()
    {
        // There is a picture in "queue", discard it
        if (_lastShot != null)
        {
            DiscardPicture();
        }

        // There is no picture in "queue", close camera
        else
        {
            CloseCamera();
        }
    }

    public static void OpenCamera()
    {
        // Picture clean-up
        DiscardPicture();
        
        // Switch active cameras and canvases
        _mainCamera.gameObject.SetActive(false);
        _firstPersonCamera.gameObject.SetActive(true);
        _simulationCamera.gameObject.SetActive(true);
        _cameraInterfaceCanvas.gameObject.SetActive(true);
        _simulationCamerasManager.enabled = true;
        
        // Enter "camera mode" action map
        GameActions.SwitchActionMap(false, true);
    }

    private static void CloseCamera()
    {
        // Picture clean-up
        DiscardPicture();
        
        // Switch active cameras and canvases
        _mainCamera.gameObject.SetActive(true);
        _firstPersonCamera.gameObject.SetActive(false);
        _simulationCamera.gameObject.SetActive(false);
        _cameraInterfaceCanvas.gameObject.SetActive(false);
        _simulationCamerasManager.enabled = false;
        
        // Exit "camera mode" action map
        GameActions.SwitchActionMap(false, false);
    }
    
    private static string EncodePictureName()
    {
        // The file name is 'CurrenScene_Date_Time.png' 
        return $"{SceneManager.GetActiveScene().name}_{DateTime.Now:yyMMdd}_{DateTime.Now:HHmmss}.png";
    }
}
