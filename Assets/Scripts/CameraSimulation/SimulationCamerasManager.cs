using UnityEngine;
using UnityEngine.Serialization;
using static GameManager;

public class SimulationCamerasManager : MonoBehaviour
{
    internal Camera FirstPersonCamera;
    internal Camera SimulationCamera;
    
    public void LateUpdate()
    {
        if (enabled)
            SimulationCamera.Render();
    }

    public void Look(Vector2 lookValue)
    {
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
