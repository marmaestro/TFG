using UnityEngine;
using UnityEngine.InputSystem;

public class GameActions : MonoBehaviour
{
    private static PlayerInput _playerInput;
    
    // Game-world actions
    private InputAction _moveAction;
    private InputAction _lookAction;
    private InputAction _interactAction;
    private InputAction _cancelAction;
    private InputAction _pauseAction;
    private InputAction _openCameraAction;
    
    // Camera actions
    private static InputAction _turnCameraAction;
    private static InputAction _takePictureAction;
    private static InputAction _savePictureAction;
    private InputAction _closeCameraAction;
    
    // UI actions
    private InputAction _uiNavigationAction;
    private InputAction _uiSelectAction;
    private InputAction _uiCancelAction;
    private InputAction _uiPauseAction;
    private InputAction _uiTabNavigationAction;

    public void Awake()
    {
        _playerInput = transform.parent.GetComponent<PlayerInput>();
        
        // Game-world actions
        _moveAction = _playerInput.actions["Move"];
        _lookAction = _playerInput.actions["Look"];
        _interactAction = _playerInput.actions["Interact"];
        _cancelAction = _playerInput.actions["Cancel"];
        _pauseAction = _playerInput.actions["Pause"];
        _openCameraAction = _playerInput.actions["Open Camera"];
        
        // Camera actions
        _turnCameraAction = _playerInput.actions["Turn Camera"];
        _takePictureAction = _playerInput.actions["Take Picture"];
        _savePictureAction = _playerInput.actions["Save Picture"];
        _closeCameraAction = _playerInput.actions["Close Camera"];
        
        // UI actions
        _uiNavigationAction = _playerInput.actions["Navigate"];
        _uiSelectAction = _playerInput.actions["Select"];
        _uiCancelAction = _playerInput.actions["Cancel"];
        _uiPauseAction = _playerInput.actions["Pause"];
        _uiTabNavigationAction = _playerInput.actions["Tab Navigation"];
    }

    public void Start()
    {
        // Game-world actions
        _moveAction.performed += OnMove;
        _lookAction.performed += OnLook;
        _interactAction.performed += OnInteract;
        _cancelAction.performed += OnCancel;
        _pauseAction.performed += OnPause;
        _openCameraAction.performed += OnOpenCamera;
        
        // Camera actions
        _turnCameraAction.performed += OnTurnCamera;
        _takePictureAction.performed += OnTakePicture;
        _savePictureAction.performed += OnSavePicture;
        _closeCameraAction.performed += OnCloseCamera;
        
        // UI actions
        _uiNavigationAction.performed += OnUINavigate;
        _uiSelectAction.performed += OnUISelect;
        _uiCancelAction.performed += OnUICancel;
        _uiPauseAction.performed += OnUIPause;
        _uiTabNavigationAction.performed += OnUITabNavigation;
    }

    // Game-world actions
    private void OnMove(InputAction.CallbackContext context)
    {
        // TODO : MOVE CHARACTER AROUND
    }
    
    private void OnLook(InputAction.CallbackContext context)
    {
        OrthoCameraManager.TurnCameraAround(context.ReadValue<Vector2>());
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        // TODO : INTERACT WITH SURROUNDING STUFF
    }

    private void OnCancel(InputAction.CallbackContext context)
    {
        // TODO : CANCEL ACTION / CLOSE
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
    private void OnTurnCamera(InputAction.CallbackContext context)
    {
        SimulationCamerasManager.TurnCameras(context.ReadValue<Vector2>());
    }
    
    private void OnTakePicture(InputAction.CallbackContext context)
    {
        SimulationCamerasManager.TakePicture();
    }
    
    private void OnSavePicture(InputAction.CallbackContext context)
    {
        SimulationCamerasManager.SavePicture();
    }
    
    private void OnCloseCamera(InputAction.CallbackContext context)
    {
        SimulationCamerasManager.CheckExistingPicture();    
    }

    // UI actions
    private void OnUINavigate(InputAction.CallbackContext context)
    {
        // TODO : UI NAVIGATE
    }
    
    private void OnUISelect(InputAction.CallbackContext context)
    {
        // TODO : UI SELECT / INTERACT
    }
    
    private void OnUICancel(InputAction.CallbackContext context)
    {
        // TODO : UI CANCEL
    }
    
    private void OnUIPause(InputAction.CallbackContext context)
    {
        GameManager.PauseGame(false);
    }
    
    private void OnUITabNavigation(InputAction.CallbackContext context)
    {
        // TODO : UI TAB NAVIGATION
    }

    // Other action-related methods
    public static void SwitchActionMap(bool pausedGame, bool openCamera = false)
    {
        if (pausedGame) // UI interactions available
        {
            _playerInput.SwitchCurrentActionMap("UI");              
        }
    
        else if (!openCamera) // normal interactions available
        {
            _playerInput.SwitchCurrentActionMap("Game-world");
        }

        else // camera is open, camera interactions available
        {
            _playerInput.SwitchCurrentActionMap("Camera");
        }
    }

    public static void FreezeMovement(bool freeze)
    {
        if (freeze)
        {
            _turnCameraAction.Disable();
            _takePictureAction.Disable();
            _savePictureAction.Enable();
        }

        else
        {
            _turnCameraAction.Enable();
            _takePictureAction.Enable();
            _savePictureAction.Disable();
        }
    }
}