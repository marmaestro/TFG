using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameActions : MonoBehaviour
{
    private static PlayerInput _playerInput;
    
    // Game-world actions
    private static InputAction _movePointer;
    private static InputAction _interact;
    private static InputAction _cancel;
    private static InputAction _pause;
    private static InputAction _openCamera;
    
    // Camera actions
    private static InputAction _moveCamera;
    private static InputAction _takePicture;
    private static InputAction _closeCamera;

    public void Awake()
    {
        _playerInput = transform.parent.GetComponent<PlayerInput>();
        
        // Game-world actions
        _movePointer = _playerInput.actions["Move Pointer"];
        _interact = _playerInput.actions["Interact"];
        _cancel = _playerInput.actions["Cancel"];
        _pause = _playerInput.actions["Pause"];
        _openCamera = _playerInput.actions["Open Camera"];
        
        // Camera actions
        _moveCamera = _playerInput.actions["Move Camera"];
        _takePicture = _playerInput.actions["Take Picture"];
        _closeCamera = _playerInput.actions["Close Camera"];
    }

    public void Start()
    {
        // Game-world actions
        _movePointer.performed += context => OnMovePointer(context.ReadValue<Vector2>()); 
        _interact.performed  += OnInteract;
        _cancel.performed += OnCancel;
        _pause.performed += OnPause;
        _openCamera.performed += OnOpenCamera;
        
        // Camera actions
        _moveCamera.performed += context => OnMoveCamera(context.ReadValue<Vector2>());
        _takePicture.performed += OnTakePicture;
        _closeCamera.performed += OnCloseCamera;
    }

    private void OnMovePointer(Vector2 delta)
    {
        // TODO : MOVE POINTER
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        // TODO : INTERACT
    }

    private void OnCancel(InputAction.CallbackContext context)
    {
        // TODO : CANCEL
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        GameManager.PauseGame(true);
    }

    private void OnOpenCamera(InputAction.CallbackContext context)
    {
        Cameras.OpenCamera();
    }


    // Camera actions
    private void OnMoveCamera(Vector2 delta)
    {
        SimulationCameraManager.MoveCamera(delta);
    }

    private void OnTakePicture(InputAction.CallbackContext context)
    {
        SimulationCameraManager.TakePicture();
    }

    private void OnCloseCamera(InputAction.CallbackContext context)
    {
        Cameras.CloseCamera();
    }

    // Other action-related methods
    public static void SwitchActionMap(bool openCamera = false)
    {
        _playerInput.SwitchCurrentActionMap(!openCamera ? "Game-world" : "Camera");
    }
}