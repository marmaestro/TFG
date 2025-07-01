using TFG.ExtensionMethods;
using TFG.Narrative;
using UnityEngine;
using static TFG.Game;

namespace TFG.Simulation
{
    public class CameraSimulatorExtension : CameraSimulator
    {
        private static Game game;
        private static Vector3 origin => camera.transform.position;
        private static Vector3 direction => camera.transform.forward;
        
        #region Unity Events
        public void OnEnable()
        {
            Console.Log(ConCat.Debug, "Initializing CameraSimulatorExtension");
            
            Awake();
            game = GetComponent<Game>();
            
            storyHandler.StartStorySection(game.city.sceneTags[player.location]);
            Console.Log(ConCat.Narrative, $"Story jumping to {game.city.sceneTags[player.location]}.");
        }

        #endregion
        
        #region Behvaiour Methods
        public new static void MovePointer(Vector2 delta)
        {
            CameraSimulator.MovePointer(delta);
            CastRay();
        }
        
        public static void Reflect()
        {
            CastRay(true);
        }
        #endregion
        
        #region Raycast Methods
        private static void CastRay(bool selectOption = false)
        {
            if (!Physics.Raycast(origin, direction, out RaycastHit hit, 305)
                || !hit.collider)
            {
                TextBridge.Default();
                return;
            }
            
            string hitID = IdentifyHitID(hit);
            if (hitID is null) return;
            
            if (!selectOption) TextBridge.IdentifyOption(hitID);
            else TextBridge.SelectOption(hitID);
        }
        
        private static string IdentifyHitID(RaycastHit hit)
        {
            return hit.collider.gameObject.layer.Equals(LayerMask.NameToLayer("Oneiric"))
                ? hit.collider.gameObject.name : null; 
        }
        #endregion
    }
}