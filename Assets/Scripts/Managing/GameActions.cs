using UnityEngine.InputSystem;

public static class GameActions
{
    public static readonly InputAction MoveAction = InputSystem.actions.FindAction("Move");
    public static readonly InputAction LookAction = InputSystem.actions.FindAction("Look");
    // TODO : InteractAction doesn't work
    public static readonly InputAction InteractAction = InputSystem.actions.FindAction("Interact");
    public static readonly InputAction CancelAction = InputSystem.actions.FindAction("Cancel");
    public static readonly InputAction PauseAction = InputSystem.actions.FindAction("Pause");
    public static readonly InputAction TakePictureAction = InputSystem.actions.FindAction("Take Picture");
}

public static class UIActions
{
    public static readonly InputAction NavigateAction = InputSystem.actions.FindAction("Navigate");
    public static readonly InputAction SelectAction = InputSystem.actions.FindAction("Select");
    public static readonly InputAction CancelAction = InputSystem.actions.FindAction("Cancel");
    public static readonly InputAction TabNavAction = InputSystem.actions.FindAction("Tab Navigation");
}