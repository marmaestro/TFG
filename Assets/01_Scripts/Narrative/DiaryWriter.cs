using TFG.ExtensionMethods;
using UnityEngine;

namespace TFG.Narrative
{
    public class DiaryWriter : MonoBehaviour
    {
        private void Start()
        {
            TextBridge.DiaryResults();
        }

        public static void OnDiaryAnimated()
        {
            SceneManager.LoadScene("CreditsScene");
        }
    }
}