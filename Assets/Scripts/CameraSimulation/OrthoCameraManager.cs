using UnityEngine;
using static GameManager;

public class OrthoCameraManager : MonoBehaviour
{
    internal static float sceneRotationLimit;
    internal static Camera mainCamera;

    public static void TurnCameraAround(Vector2 lookValue)
    {
        // Threshold to avoid jitter and sensitivity adjustment
        if (lookValue.x is >= -CameraRotationThreshold and <= CameraRotationThreshold) lookValue.y = 0;
        float rotation = - lookValue.x * CameraSensitivity;
        
        // Axis of rotation set-up and rotation
        Vector3 axis = Vector3.Cross(Vector3.forward, Vector3.left);
        mainCamera.transform.RotateAround(mainCamera.transform.position, axis, rotation);
        
        // Clamp the rotation inside the scene rotation limit
        mainCamera.transform.eulerAngles = new Vector3(mainCamera.transform.eulerAngles.x, Clamp(mainCamera.transform.eulerAngles.y, sceneRotationLimit), mainCamera.transform.eulerAngles.z);
    }

    private static float Clamp(float value, float limit)
    {
        // Convert angles into something Mathf.Clamp and Unity understand
        float corrected = value switch
        {
            < 0 => 360 + value,
            > 0 and < CameraAngle - 180 => 360 + value,
            _ => value
        };

        return Mathf.Clamp(corrected, CameraAngle - limit, CameraAngle + limit);
    }
}
