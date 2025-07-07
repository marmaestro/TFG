using TFG.Animation;
using UnityEngine;

namespace TFG.Narrative
{
    public static class TextBridge
    {
        private static Rewriter rewriter => GameObject.FindGameObjectWithTag("AnimatedText").GetComponent<Rewriter>();
        
        public static void CurrentLine()
        {
            string text = StoryHandler.GetLine();
            rewriter.Rewrite(text);
        }
        
        public static bool NextLine()
        {
            if (StoryHandler.canContinue)
            {
                string text = StoryHandler.Step();
                rewriter.Rewrite(text);
                return true;
            }
            
            return false;
        }
        
        public static void Clear()
        {
            rewriter.Clear();
        }
        
        public static void IdentifyOption(string textID)
        {
            string text = StoryHandler.GetOptionText(textID);
            rewriter.Rewrite(text);
        }
        
        public static void SelectOption(string textID)
        {
            int optionID = StoryHandler.GetOptionIndex(textID);
            
            StoryHandler.Choose(optionID);
            rewriter.Rewrite(StoryHandler.GetLine());
            
            if (int.TryParse(textID[^1..], out int _))
                textID = "finished";
            
            LocationAnimator.TriggerAnimation(textID);
        }

        public static void DiaryResults()
        {
            string text = StoryHandler.GetDiary();
            rewriter.Rewrite(text);
        }
    }
}