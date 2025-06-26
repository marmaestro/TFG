using TFG.Narrative;
using UnityEngine;

namespace TFG.Simulation
{
    public class CameraSimulatorExtension : CameraSimulator
    {
        #region Behvaiour Methods
        public static void Reflect()
        {
            CastRays(true);
        }
        #endregion
        
        #region Raycast Methods
        private static void CastRays(bool reflecting = false)
        {
            Vector3 origin = camera.transform.position;
            Vector3 direction = camera.transform.forward;

            Physics.Raycast(origin, direction, out RaycastHit hit, Mathf.Infinity, LayerMask.NameToLayer("Oneiric"), QueryTriggerInteraction.Collide);
            if (reflecting)
                DialogueBridge.IdentifyOption(ProcessRayCast(hit));
                
            else ProcessRayCast(hit!);
        }
        
        private static string ProcessRayCast(RaycastHit hit)
        {
            return hit.collider.gameObject.layer == LayerMask.NameToLayer("Oneiric") ?
                   hit.collider.gameObject.name : null;
        }
        #endregion
    }
}