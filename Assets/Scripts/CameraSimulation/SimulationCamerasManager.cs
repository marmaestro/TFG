using System;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

public class SimulationCamerasManager : MonoBehaviour
{
    internal static Camera firstPersonCamera;
    internal static Camera simulationCamera;
    
    private static GameObject _pictureInterface;
    
    private static string _savedImagesPath;
    
    private static RenderTexture _renderTarget;
    private static Texture2D _lastShot;

    // Unity events
    public void Awake()
    {
        _pictureInterface = GameObject.Find("PictureInterface");
        
        _savedImagesPath = Application.dataPath + "/Resources/Images/Saved/";
        
        _renderTarget = Resources.Load("Images/Renders/PolaroidOutput") as RenderTexture;
        _lastShot = null; 
    }

    public void Start()
    {
        DiscardPicture();
    }
    
    public void LateUpdate()
    {

        // Viewfinder rendering
        if (enabled)
        {
            try
            {
                simulationCamera.Render();
            }

            catch (Exception e)
            {
                Debug.LogError($"Cagamos, con error {e}.");
            }
        }
    }

    // Behaviour
    public static void TurnCameras(Vector2 lookValue)
    {
        // Threshold to avoid jitter
        if (lookValue.x is <= CameraRotationThreshold and >= -CameraRotationThreshold) lookValue.x = 0;
        if (lookValue.y is <= CameraRotationThreshold and >= -CameraRotationThreshold) lookValue.y = 0;

        // Sensitivity and axis adjustments
        float xRotation = -lookValue.y * CameraSensitivity;
        float yRotation = lookValue.x * CameraSensitivity;
        
        // Rotation
        Vector3 rotation = new(xRotation, yRotation, 0);
        firstPersonCamera.transform.eulerAngles += rotation;

        // Clamp the rotation inside the predefined angle
        float adjustedRotationX = Clamp(firstPersonCamera.transform.eulerAngles.x, -40f, 30f);
        float adjustedRotationY = Clamp(firstPersonCamera.transform.eulerAngles.y, -60f, 60f);
        firstPersonCamera.transform.eulerAngles = new Vector3(adjustedRotationX, adjustedRotationY, 0);
        
        // Update simulation camera
        simulationCamera.transform.eulerAngles = firstPersonCamera.transform.eulerAngles;
    }

    public static void TakePicture()
    {
        // Call the camera to render
        try
        {
            simulationCamera.Render();
        }

        catch (Exception e)
        {
            Debug.LogError($"Cagamos, con error {e}.");
        }
        
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
    
    // Auxiliar methods
    private static float Clamp(float value, float min, float max, float cameraAngle = 0)
    {
        // Convert angles into something Mathf.Clamp and Unity understand
        if (value > 180) value = -360 + value;
        
        return Mathf.Clamp(value, cameraAngle + min, cameraAngle + max);

    }

    internal static void CheckExistingPicture()
    {
        // There is a picture in "queue", discard it
        if (_lastShot != null)
        {
            DiscardPicture();
        }

        // There is no picture in "queue", close camera
        else
        {
            Cameras.CloseCamera();
        }
    }
    
    private static string EncodePictureName()
    {
        // The file name is 'CurrenScene_Date_Time.png' 
        return $"{SceneManager.GetActiveScene().name}_{DateTime.Now:yyMMdd}_{DateTime.Now:HHmmss}.png";
    }
}
