using TFG.Narrative;
using UnityEngine;

namespace TFG.Simulation
{
    public class CameraReflector : MonoBehaviour
    {
        private new static Camera camera;

        public void Awake()
        {
            camera = GetComponent<Camera>();
        }
        
        #region Behvaiour Methods
        public static void MovePointer(Vector2 delta)
        {
            camera.transform.position = new Vector3(delta.x, delta.y, camera.transform.position.z);
            CastRays();
        }

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
        #endregion

        #region Raycast Processing
        private static string ProcessRayCast(RaycastHit hit)
        {
            return hit.collider.gameObject.layer == LayerMask.NameToLayer("Oneiric") ? hit.collider.gameObject.name : null;
        }
        #endregion
    }
}