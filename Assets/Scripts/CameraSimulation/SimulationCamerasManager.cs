using UnityEngine;
using static GameManager;

public class SimulationCamerasManager : MonoBehaviour
{
    private const float CameraRotationThreshold = 0.05f;

    internal Camera FirstPersonCamera;
    internal Camera SimulationCamera;
    [SerializeField] private RenderTexture targetRenderTexture;

    public void FixedUpdate ()
    {
        RotateCameras();
    }
    
    public void LateUpdate()
    {
        SimulationCamera.Render();
    }

    private void RotateCameras()
    {
        Vector2 lookValue = GameActions.LookAction.ReadValue<Vector2>().normalized;
        if (lookValue.x is <= CameraRotationThreshold and >= -CameraRotationThreshold) lookValue.x = 0;
        if (lookValue.y is <= CameraRotationThreshold and >= -CameraRotationThreshold) lookValue.y = 0;

        float xRotation = -lookValue.y * CameraSensitivity;
        float yRotation = lookValue.x * CameraSensitivity;
        
        Vector3 rotation = new(xRotation, yRotation, 0);
        FirstPersonCamera.transform.eulerAngles += rotation;

        float adjustedRotationX = Clamp(FirstPersonCamera.transform.eulerAngles.x, -40f, 30f);
        float adjustedRotationY = Clamp(FirstPersonCamera.transform.eulerAngles.y, -60f, 60f);
        FirstPersonCamera.transform.eulerAngles = new Vector3(adjustedRotationX, adjustedRotationY, 0);
        
        SimulationCamera.transform.eulerAngles = FirstPersonCamera.transform.eulerAngles;
    }
    
    private static float Clamp(float value, float min, float max, float cameraAngle = 0)
    {
        if (value > 180) value = -360 + value;
        return Mathf.Clamp(value, cameraAngle + min, cameraAngle + max);

    }
}
