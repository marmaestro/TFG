using UnityEngine;
using UnityEngine.InputSystem;

public class GameActions : MonoBehaviour
{
    private static PlayerInput _playerInput;
    
    private static InputAction _turnCameraAction;
    private static InputAction _savePictureAction;

    public void Awake()
    {
        _playerInput = transform.parent.GetComponent<PlayerInput>();
        
        _turnCameraAction = _playerInput.actions.FindAction("Turn Camera");
        _savePictureAction = _playerInput.actions.FindAction("Save Picture");
    }

    // Game-world actions
    public static void OnMove(InputAction.CallbackContext context)
    {
        // TODO : MOVE CHARACTER AROUND
        if (context.phase == InputActionPhase.Performed)
        {
            
        }
    }
    
    public static void OnLook(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) {
            CameraWorks.TurnCameraAround(context.ReadValue<Vector2>());
        }
    }

    public static void OnInteract(InputAction.CallbackContext context)
    {
        // TODO : INTERACT WITH SURROUNDING STUFF
        if (context.phase == InputActionPhase.Performed)
        {
            
        }
    }

    public static void OnCancel(InputAction.CallbackContext context)
    {
        // TODO : CANCEL ACTION / CLOSE
        if (context.phase == InputActionPhase.Performed)
        {
            
        }
    }
    
    public static void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            GameManager.PauseGame(true);
        }
    }
    
    public static void OnOpenCamera(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            CameraWorks.OpenCamera();
        }
    }
    
    // Camera actions
    public static void OnTurnCamera(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            CameraWorks.TurnCamera(context.ReadValue<Vector2>());
        }
    }
    
    public static void OnTakePicture(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            CameraWorks.TakePicture();
        }
    }
    
    public static void OnSavePicture(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            CameraWorks.SavePicture();
        }
    }
    
    public static void OnCloseCamera(InputAction.CallbackContext context)
    {
        // TODO : CHECK IF DISCARD PICTURE
        if (context.phase == InputActionPhase.Performed)
        {
            CameraWorks.CheckExistingPicture();
        }    
    }

    // UI actions
    public static void OnUINavigate(InputAction.CallbackContext context)
    {
        // TODO : UI NAVIGATE
        if (context.phase == InputActionPhase.Performed)
        {
            
        }
    }
    
    public static void OnUISelect(InputAction.CallbackContext context)
    {
        // TODO : UI SELECT / INTERACT
        if (context.phase == InputActionPhase.Performed)
        {
            
        }
    }
    
    public static void OnUICancel(InputAction.CallbackContext context)
    {
        // TODO : UI CANCEL
        if (context.phase == InputActionPhase.Performed)
        {
            
        }
    }
    
    public static void OnUIPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            GameManager.PauseGame(false);
        }
    }
    
    public static void OnUITabNavigation(InputAction.CallbackContext context)
    {
        // TODO : UI TAB NAVIGATION
        if (context.phase == InputActionPhase.Performed)
        {
            
        }
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
            _savePictureAction.Enable();
        }

        else
        {
            _turnCameraAction.Enable();
            _savePictureAction.Disable();
        }
    }
}