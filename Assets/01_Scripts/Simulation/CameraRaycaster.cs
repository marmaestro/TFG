using TFG.ExtensionMethods;
using TFG.Narrative;
using UnityEngine;
using static TFG.Game;

namespace TFG.Simulation
{
    public partial class CameraSimulator
    {
        private static Vector3 origin => camera.transform.position;
        private static Vector3 direction => camera.transform.forward;
        
        #region Behvaiour Methods
        private static void LoadReflecting()
        {
            game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();
            storyHandler.StartStorySection(game.city.sceneTags[player.location]);
        }
        
        public static void Reflect()
        {
            CastRay(true);
        }
        #endregion
        
        #region Raycast Methods
        private static void CastRay(bool selectOption = false)
        {
            if (!Physics.Raycast(origin, direction, out RaycastHit hit, 305) || !hit.collider)
            {
                TextBridge.Default();
                return;
            }
            
            string hitName = IdentifyHitID(hit);
            if (hitName is null) return;
            
            if (!selectOption) TextBridge.IdentifyOption(hitName);
            else TextBridge.SelectOption(hitName);
        }
        
        private static string IdentifyHitID(RaycastHit hit)
        {
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (hit.collider.gameObject.layer.Equals(LayerMask.NameToLayer("Oneiric")))
                return hit.collider.gameObject.name;

            return null;
        }
        #endregion
    }
}