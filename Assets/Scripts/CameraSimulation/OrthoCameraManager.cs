using UnityEngine;
using static GameManager;

public class OrthoCameraManager : MonoBehaviour
{
    [SerializeField] private float sceneRotationLimit;
    [SerializeField] private float sceneRotationThreshold;
    
    public void FixedUpdate ()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        Vector2 lookValue = LookAction.ReadValue<Vector2>().normalized;
        if (lookValue.x >= -sceneRotationThreshold && lookValue.x <= sceneRotationThreshold) lookValue.y = 0;
        float rotation = - lookValue.x * CameraSensitivity;
        
        Vector3 axis = Vector3.Cross(Vector3.forward, Vector3.left);
        transform.RotateAround(transform.position, axis, rotation);
        
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Clamp(transform.eulerAngles.y, sceneRotationLimit), transform.eulerAngles.z);
    }
}
