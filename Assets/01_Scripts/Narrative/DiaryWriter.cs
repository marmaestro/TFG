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
            leftTextBlock.text = rawText[..maxChars];
            diaryAnimator.AnimateLeft();

            
        }

        public void OnLeftAnimated()
        {
            rightTextBlock.text = rawText[maxChars..rawText.Length];
            diaryAnimator.AnimateRight();
        }
    }    
}