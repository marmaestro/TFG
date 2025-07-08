using TFG.ExtensionMethods;
using TFG.InputSystem;
using UnityEngine;

namespace TFG.Narrative
{
    public class DiaryWriter : MonoBehaviour
    {
        private void Start()
        {
            GameActions.CursorToggle(false);
            TextBridge.DiaryResults();
        }

        public static void OnDiaryAnimated()
        {
            SceneManager.LoadScene("CreditsScene");
        }
    }
}