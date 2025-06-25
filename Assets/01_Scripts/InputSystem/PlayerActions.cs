using System;
using System.ComponentModel;
using TFG.ExtensionMethods;
using TFG.Simulation;
using UnityEngine;
using UnityEngine.InputSystem;
using Console = TFG.ExtensionMethods.Console;

namespace TFG.InputSystem
{
    public class PlayerActions : MonoBehaviour
    {
        private static PlayerInput playerInput;
        
        #region Action Definitions
        // World
        private InputAction navigate;
        private InputAction openCamera;
        private InputAction pause;
        
        // Camera
        private InputAction moveCamera;
        private InputAction takePicture;
        private InputAction closeCamera;
        
        // Reflections
        private InputAction moveFocusPoint;
        private InputAction reflect;

        public void Awake()
        {
            playerInput = transform.parent.GetComponent<PlayerInput>();
        
            // World
            navigate = playerInput.actions["Navigate"];
            openCamera = playerInput.actions["Open Camera"];
            pause = playerInput.actions["Pause"];
            
            // Camera
            moveCamera = playerInput.actions["Move Camera"];
            //takePicture = playerInput.actions["Take Picture"];
            closeCamera = playerInput.actions["Close Camera"];
            
            // Reflections
            moveFocusPoint = playerInput.actions["Move Focus Point"];
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
            //takePicture.performed += OnTakePicture;
            closeCamera.performed += OnCloseCamera;
            
            // Reflect
            moveFocusPoint.performed += context => OnMoveFocusPoint(context.ReadValue<Vector2>());
            reflect.performed += OnReflect;
        }
        #endregion

        #region World Actions
        private void OnNavigate(Vector2 delta)
        {
            if (Game.player.steps > 0)
                InputDecoding.ParseDelta(delta);
        }
        private void OnOpenCamera(InputAction.CallbackContext context)
        {
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
        /*private void OnTakePicture(InputAction.CallbackContext context)
        {
            CameraSimulator.TakePicture();
        }*/
        private void OnCloseCamera(InputAction.CallbackContext context)
        {
            CameraSimulator.Close();
        }
        #endregion
        
        #region Reflection Actions

        private static void OnMoveFocusPoint(Vector2 delta)
        {
            CameraReflector.MovePointer(delta);
        }
        private static void OnReflect(InputAction.CallbackContext context)
        {
            CameraReflector.Reflect();
        }
        #endregion
        
        public static void SwitchActionMap(ActionMaps actionMap)
        {
            if (!Enum.IsDefined(typeof(ActionMaps), actionMap))
                throw new InvalidEnumArgumentException($"{actionMap} is not defined.");
            
            Console.Log(ConsoleCategories.Debug, $"Switching action map to <u>{actionMap}</u>.");
            playerInput.SwitchCurrentActionMap(actionMap.ToString());
        }
        
        public static void PauseInputSystem()
        {
            playerInput.enabled = !playerInput.enabled;
        }
    }
}