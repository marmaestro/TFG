using UnityEngine;
using static GameManager;

public class OrthoCameraManager : MonoBehaviour
{
    internal float SceneRotationLimit;

    internal Camera MainCamera;

    public void TurnCameraAround(Vector2 lookValue)
    {
        if (lookValue.x is >= -CameraRotationThreshold and <= CameraRotationThreshold) lookValue.y = 0;
        float rotation = - lookValue.x * CameraSensitivity;
        
        Vector3 axis = Vector3.Cross(Vector3.forward, Vector3.left);
        MainCamera.transform.RotateAround(MainCamera.transform.position, axis, rotation);
        
        MainCamera.transform.eulerAngles = new Vector3(MainCamera.transform.eulerAngles.x, Clamp(MainCamera.transform.eulerAngles.y, SceneRotationLimit), MainCamera.transform.eulerAngles.z);
    }
    
    private static float Clamp(float value, float limit)
    {   
        float clamped = Mathf.Clamp(value, CameraAngle - limit, CameraAngle + limit);
        return clamped switch
        {
            < 0   => clamped + 360,
            > 360 => clamped - 360,
            _     => clamped
        };
    }
}
