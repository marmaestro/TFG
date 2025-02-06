using System;
using UnityEngine;
using UnityEngine.SceneManagement;
// ReSharper disable RedundantArgumentDefaultValue

public class Cameras : MonoBehaviour
{
    [SerializeField] private float sceneRotationLimit;
    
    private static Camera _mainCamera;
    private static Camera _firstPersonCamera;
    private static Camera _simulationCamera;

    public void Awake()
    {
        // Load cameras
        Camera[] cameras = FindObjectsByType<Camera>(FindObjectsSortMode.None);
        _mainCamera = Array.Find(cameras, it => it.name == "Main");
        _firstPersonCamera = Array.Find(cameras, it => it.name == "FirstPerson");
        _simulationCamera = Array.Find(cameras, it => it.name == "Simulation");
        
        // Set-up main camera and settings
        OrthoCameraManager.sceneRotationLimit = sceneRotationLimit;
        OrthoCameraManager.mainCamera = _mainCamera;
        
        // Set-up simulation cameras
        SimulationCamerasManager.firstPersonCamera = _firstPersonCamera;
        SimulationCamerasManager.simulationCamera = _simulationCamera;
    }

    public static void OpenCamera()
    {
        // Open picture interface / camera simulation
        SimulationStart();
        // Switch active action map
        GameActions.SwitchActionMap(false, true);
    }

    public static void CloseCamera()
    {
        // Close picture interface / camera simulation
        SimulationEnd();
        // Switch active action map
        GameActions.SwitchActionMap(false, false);
    }

    private static void SimulationStart()
    {
        SceneManager.LoadScene("Scenes/CameraInterface", LoadSceneMode.Additive);
    }

    private static void SimulationEnd()
    {
        SceneManager.UnloadSceneAsync("Scenes/CameraInterface");
    }
}
