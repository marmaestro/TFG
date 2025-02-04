using UnityEngine;

public class CameraWorks : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera firstPersonCamera;
    [SerializeField] private Camera simulationCamera;
    [SerializeField] private Canvas photoCanvas;

    [SerializeField] private string renderedImagesPath;
    [SerializeField] private string savedImagesPath;
    
    [SerializeField] private RenderTexture renderTarget;
    private Texture2D _lastShot;
    
    private SimulationCamerasManager _simulationCamerasManager;

    private bool _cameraIsOpen;

    public void Start()
    {
        _simulationCamerasManager = transform.GetComponent<SimulationCamerasManager>();
        _simulationCamerasManager.FirstPersonCamera = firstPersonCamera;
        _simulationCamerasManager.SimulationCamera = simulationCamera;
    }

    public void Update()
    {
        CameraStatus();
    }

    private void CameraStatus()
    {
        if (GameActions.TakePictureAction.WasPerformedThisFrame())
        {
            if (_cameraIsOpen) TakePicture();
            else
            {
                Debug.Log("Abriendo");
                OpenCamera();
            }
        }

        if (GameActions.InteractAction.WasPerformedThisFrame() && _cameraIsOpen)
        {
            // TODO : check "last picture"
            SavePicture();
        }

        if (GameActions.CancelAction.WasPerformedThisFrame() && _cameraIsOpen)
        {
            CloseCamera();
        }
    }

    private void SavePicture()
    {
        Debug.Log("¡GUARDANDO!");
        System.IO.File.WriteAllBytes($"{renderedImagesPath}shot_{Time.time}.png", _lastShot.EncodeToPNG());
    }

    private void TakePicture()
    {
        Debug.Log("¡PATATA!");
        simulationCamera.Render();
        _lastShot = new Texture2D(renderTarget.width, renderTarget.height, TextureFormat.ETC2_RGBA8, false);
    }

    private void OpenCamera()
    {
        mainCamera.gameObject.SetActive(false);
        firstPersonCamera.gameObject.SetActive(true);
        simulationCamera.gameObject.SetActive(true);
        photoCanvas.gameObject.SetActive(true);
        _cameraIsOpen = true;
    }

    private void CloseCamera()
    {
        mainCamera.gameObject.SetActive(true);
        firstPersonCamera.gameObject.SetActive(false);
        simulationCamera.gameObject.SetActive(false);
        photoCanvas.gameObject.SetActive(false);
        _cameraIsOpen = false;
    }
}
