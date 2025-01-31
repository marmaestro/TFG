using UnityEngine;
using static GameManager;

public class SimulationCamerasManager : MonoBehaviour
{
    private const float CameraRotationThreshold = 0.05f;

    [SerializeField] private Camera firstPersonCamera;
    [SerializeField] private Camera simulationCamera;
    [SerializeField] private RenderTexture targetRenderTexture;

    public void FixedUpdate ()
    {
        RotateCameras();
    }
    
    public void LateUpdate()
    {
        simulationCamera.Render();
    }

    private void RotateCameras()
    {
        Vector2 lookValue = LookAction.ReadValue<Vector2>().normalized;
        if (lookValue.x is <= CameraRotationThreshold and >= -CameraRotationThreshold) lookValue.x = 0;
        if (lookValue.y is <= CameraRotationThreshold and >= -CameraRotationThreshold) lookValue.y = 0;

        float xRotation = Mathf.Clamp( lookValue.y * CameraSensitivity, -60f, 60f);
        float yRotation = Mathf.Clamp(-lookValue.x * CameraSensitivity, -45f, 90f);
        
        Vector3 rotation = new(xRotation, yRotation, 0);
        
        firstPersonCamera.transform.eulerAngles += rotation;
        simulationCamera.transform.eulerAngles += rotation;

        float adjustedRotationX = Mathf.Clamp(firstPersonCamera.transform.eulerAngles.z, -60f, 60f);
        float adjustedRotationY = Mathf.Clamp(firstPersonCamera.transform.eulerAngles.y, -60f, 60f); 
        firstPersonCamera.transform.eulerAngles.Set(adjustedRotationX, adjustedRotationY, 0f);
        simulationCamera.transform.eulerAngles.Set(adjustedRotationX, adjustedRotationY, 0f);
    }
}
