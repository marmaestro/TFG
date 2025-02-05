using UnityEngine;
using UnityEngine.InputSystem;

public class GameActions : MonoBehaviour
{
    public static InputSettings inputSettings;
    // Game-world actions
    /*
    public static InputAction moveAction;
    public static InputAction LookAction;
    public static InputAction InteractAction; // TODO : InteractAction doesn't work
    public static InputAction CancelAction;
    public static InputAction PauseAction;
    public static InputAction TakePictureAction;
    */
    
    // UI actions
    /*
    public static InputAction UINavigateAction;
    public static InputAction UISelectAction;
    public static InputAction UICancelAction;
    public static InputAction UITabNavAction;
    */

    public void Awake()
    {
        inputSettings = InputSystem.settings;

        /*
        moveAction = InputSystem.actions.FindAction("Move");
        LookAction = InputSystem.actions.FindAction("Look");
        InteractAction = InputSystem.actions.FindAction("Interact");
        CancelAction = InputSystem.actions.FindAction("Cancel");
        PauseAction = InputSystem.actions.FindAction("Pause");
        TakePictureAction = InputSystem.actions.FindAction("Take Picture");
        */
        /*
        UINavigateAction = InputSystem.actions.FindAction("Navigate");
        UISelectAction = InputSystem.actions.FindAction("Select");
        UICancelAction = InputSystem.actions.FindAction("Cancel");
        UITabNavAction = InputSystem.actions.FindAction("Tab Navigation");
        */
    }

    public void OnMoveAction(InputAction.CallbackContext context)
    {
        PlayerManager.Move(context.ReadValue<Vector2>());
    }

    public void OnLookAction(InputAction.CallbackContext context)
    {
        CameraWorks.Look(context.ReadValue<Vector2>());
    }

    public void OnInteractAction(InputAction.CallbackContext context)
    {
        PlayerManager.Interact();
    }

    public void OnCancelAction(InputAction.CallbackContext context)
    {
        PlayerManager.Cancel();
    }

    public void OnPauseAction(InputAction.CallbackContext context)
    {
        GameManager.PauseGame(true);
    }

    public void OnTakePictureAction(InputAction.CallbackContext context)
    {
        PlayerManager.TakePicture();
    }

    public void OnUINavigateAction(InputAction.CallbackContext context) { }

    public void OnUISelectAction(InputAction.CallbackContext context) { }

    public void OnUICancelAction(InputAction.CallbackContext context) { }

    public void OnUITabNavAction(InputAction.CallbackContext context) { }
}