using EasyTextEffects.Editor.MyBoxCopy.Extensions;
using TFG.Animation;
using TFG.ExtensionMethods;
using UnityEngine;

namespace TFG.Narrative
{
    public static class TextBridge
    {
        private static Rewriter rewriter => GameObject.FindGameObjectWithTag("AnimatedText").GetComponent<Rewriter>();

        
        public static void Default()
        {
            string text = StoryHandler.GetText();
            rewriter.Rewrite(text);
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
            rewriter.Rewrite(StoryHandler.GetPathText());
            
            LocationAnimator.TriggerAnimation(textID);
        }
    }
}