using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using static TFG.Simulation.CameraSimulator;

namespace TFG.InputSystem
{
    public class Actions : MonoBehaviour
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
            takePicture = playerInput.actions["Take Picture"];
            closeCamera = playerInput.actions["Close Camera"];
            
            // Reflections
            moveFocusPoint = playerInput.actions["Move Focus Point"];
            reflect = playerInput.actions["Reflect Further"];
        }
        #endregion

        public void Start()
        {
            // World
            navigate.performed += context => OnNavigate(context.ReadValue<Vector2>());
            openCamera.performed += OnOpenCamera;
            pause.performed += OnPause;
            
            // Camera
            moveCamera.performed += context => OnMoveCamera(context.ReadValue<Vector2>());
            takePicture.performed += OnTakePicture;
            closeCamera.performed += OnCloseCamera;
            
            // Reflect
            moveFocusPoint.performed += context => OnMoveFocusPoint(context.ReadValue<Vector2>());
            reflect.performed += context => OnReflect(context.ReadValue<Vector2>());
        }

        #region World Actions
        private void OnNavigate(Vector2 delta)
        {
            // TODO : NAVIGATE
        }
        private void OnOpenCamera(InputAction.CallbackContext context)
        {
            OpenCamera();
        }
        private void OnPause(InputAction.CallbackContext context)
        {
            Game.PauseGame(true);
        }
        #endregion

        #region Camera Actions
        private static void OnMoveCamera(Vector2 delta)
        {
            MoveCamera(delta);
        }
        private void OnTakePicture(InputAction.CallbackContext context)
        {
            TakePicture();
        }
        private void OnCloseCamera(InputAction.CallbackContext context)
        {
            CloseCamera();
        }
        #endregion
        
        #region Reflection Actions
        private void OnMoveFocusPoint(Vector2 delta)
        {
            // TODO : MOVE IN REFLECTION
        }
        private void OnReflect(Vector2 delta)
        {
            // TODO : REFLECT
        }
        #endregion
        
        public static void SwitchActionMap(ActionMaps actionMap)
        {
            if (!Enum.IsDefined(typeof(ActionMaps), actionMap))
                throw new InvalidEnumArgumentException($"{nameof(actionMap)} is not defined.");
            
            playerInput.SwitchCurrentActionMap(nameof(actionMap));
        }
        
        public static void PauseInputSystem()
        {
            playerInput.enabled = !playerInput.enabled;
        }
    }
}