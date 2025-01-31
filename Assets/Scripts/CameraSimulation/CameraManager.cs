using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera simulationCamera;
    [SerializeField] private RenderTexture targetRenderTexture;

    private const float Sensitivity = 2;
    private InputAction _lookAction;

    public void Awake()
    {
        _lookAction = InputSystem.actions.FindAction("Look");
        //_lookAction.Enable();
    }

    public void FixedUpdate ()
    {
        Vector2 lookValue = _lookAction.ReadValue<Vector2>();
        
        // TODO : Check weird movement
        mainCamera.transform.Rotate(-transform.up * (lookValue.x * Sensitivity));
        mainCamera.transform.Rotate(transform.right * (lookValue.y * Sensitivity));
        
        simulationCamera.transform.Rotate(-transform.up * (lookValue.x * Sensitivity));
        simulationCamera.transform.Rotate(transform.right * (lookValue.y * Sensitivity));
    }
    
    public void LateUpdate()
    {
        simulationCamera.Render();
    }
}
