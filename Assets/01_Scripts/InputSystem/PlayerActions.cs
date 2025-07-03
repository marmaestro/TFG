using System;
using System.ComponentModel;
using System.Diagnostics;
using TFG.ExtensionMethods;
using TFG.Simulation;
using UnityEngine;
using UnityEngine.InputSystem;
using Console = TFG.ExtensionMethods.Console;
using static TFG.Game;
using static TFG.NavigationSystem.Navigation;

namespace TFG.InputSystem
{
    public class PlayerActions : MonoBehaviour
    {
        private static PlayerInput playerInput;
        
        #region Action Definitions
        // World
        private static InputAction navigate;
        private static InputAction openCamera;
        private static InputAction pause;
        
        // Camera
        private static InputAction moveCamera;
        private static InputAction closeCamera;
        
        // Reflections
        private static InputAction moveCameraReflecting;
        private static InputAction reflect;

        public void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
        
            // World
            navigate = playerInput.actions["Navigate"];
            openCamera = playerInput.actions["Open Camera"];
            pause = playerInput.actions["Pause"];
            
            // Camera
            moveCamera = playerInput.actions["Move Camera"];
            closeCamera = playerInput.actions["Close Camera"];
            
            // Reflections
            moveCameraReflecting = playerInput.actions["Move Camera (Reflecting)"];
            reflect = playerInput.actions["Reflect Further"];
        }

        public void Start()
        {
            // World
            navigate.performed += context => OnNavigate(context.ReadValue<Vector2>());
            openCamera.performed += OnOpenCamera;
            pause.performed += OnPause;
            
            // Camera
            moveCamera.performed += context => OnMoveCamera(context.ReadValue<Vector2>());
            closeCamera.performed += OnCloseCamera;
            
            // Reflect
            moveCameraReflecting.performed += context => OnMoveCamera(context.ReadValue<Vector2>());
            reflect.performed += OnReflect;
        }
        #endregion

        #region World Actions
        private void OnNavigate(Vector2 delta)
        {
            if (player.steps >= 0)
                InputDecoding.ParseDelta(delta);
        }
        private void OnOpenCamera(InputAction.CallbackContext context)
        {
            if (!navigation.currentLocationName.Equals(Home))
                CameraSimulator.OpenCamera();
        }
        private void OnPause(InputAction.CallbackContext context)
        {
            Game.PauseGame(true);
        }
        #endregion

        #region Camera Actions
        private static void OnMoveCamera(Vector2 delta)
        {
            CameraSimulator.MovePointer(delta);
        }
        private void OnCloseCamera(InputAction.CallbackContext context)
        {
            CameraSimulator.CloseCamera();
        }
        #endregion
        
        #region Reflection Actions
        private static void OnReflect(InputAction.CallbackContext context)
        {
            CameraSimulator.Reflect();
        }
        #endregion
        
        #region Input System Custom Methods
        public static void SwitchActionMap(ActionMaps actionMap)
        {
            if (!Enum.IsDefined(typeof(ActionMaps), actionMap))
                throw new InvalidEnumArgumentException($"{actionMap} is not defined.");
            
            playerInput.SwitchCurrentActionMap(actionMap.ToString());
            CursorToggle(actionMap.Equals(ActionMaps.UI));

            #if DEBUG
            Console.Log(ConCat.InputSystem, $"Switching action map to <b>{actionMap}</b>.");
            #endif
        }
        
        public static void PauseInputSystem()
        {
            playerInput.enabled = !playerInput.enabled;
        }
        
        private static void CursorToggle(bool show)
        {
            Cursor.visible = show;
        }
        
        #if UNITY_EDITOR
        [Conditional("UNITY_EDITOR")]
        public void Show()
        {
            if (Application.isPlaying)
            {
                Console.Log(ConCat.InputSystem, $"Current action map is <b>{playerInput.currentActionMap.name}</b>.");
            }

            else
            {
                Console.LogWarning(ConCat.InputSystem, "This debug button only works in <b>Play</b> mode.");
            }
        }
        #endif
        #endregion
    }
}