using TFG.Animation;
using TMPro;
using UnityEngine;

namespace TFG.Narrative
{
    public class DiaryWriter : MonoBehaviour
    {
        [SerializeField] private TMP_Text leftTextBlock;
        [SerializeField] private TMP_Text rightTextBlock;

        private string rawText;
        private DiaryAnimator diaryAnimator;

        private const int maxChars = 500;

        public void Awake()
        {
            diaryAnimator = GetComponent<DiaryAnimator>();
            diaryAnimator.Init(leftTextBlock, rightTextBlock);
        }

        public void Start()
        {
            rawText = StoryHandler.GetDiary();
            Format();
        }

        private void Format()
        {
            leftTextBlock.text = rawText.Length > maxChars ? rawText[..maxChars] : rawText;
            diaryAnimator.AnimateLeft();
        }

        public void OnLeftAnimated()
        {
            if (rawText.Length > maxChars) rightTextBlock.text = rawText[maxChars..rawText.Length];
            diaryAnimator.AnimateRight();
        }
    }    
}