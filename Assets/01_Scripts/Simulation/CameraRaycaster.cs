using TFG.InputSystem;
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
            StoryHandler.StartStorySection(game.city.sceneTags[player.location]);
            game.city.visitedLocations[player.location] = true;
        }
        
        public static void Reflect()
        {
            if (TextBridge.NextLine()) return;

            if (!reflecting && !TextBridge.NextLine())
            {
                GameActions.SwitchActionMap(ActionMaps.Camera);
                TextBridge.Clear();
                return;
            }

            CastRay(true);
        }
        
        public static void StopReflecting()
        {
            reflecting = false;
        }
        #endregion
        
        #region Raycast Methods
        private static void CastRay(bool selectOption = false)
        {
            Debug.DrawRay(origin, direction * 305, Color.red, 25f);
            
            if (!Physics.Raycast(origin, direction, out RaycastHit hit, 305) || !hit.collider)
            {
                TextBridge.CurrentLine();
                return;
            }
            
            string hitName = IdentifyHitID(hit);
            if (hitName is null) return;
            
            if (!selectOption) TextBridge.IdentifyOption(hitName);
            else
            {
                soundEvents[Shutter].Play();
                TextBridge.SelectOption(hitName);
            }
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