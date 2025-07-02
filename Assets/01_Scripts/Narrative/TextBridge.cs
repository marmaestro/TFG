using EasyTextEffects.Editor.MyBoxCopy.Extensions;
using TFG.Animation;
using TFG.ExtensionMethods;
using UnityEngine;

namespace TFG.Narrative
{
    public static class TextBridge
    {
        private static Rewriter rewriter => GameObject.FindGameObjectWithTag("AnimatedText").GetComponent<Rewriter>();

        private static void Print(string text)
        {
            Console.Log(ConCat.Narrative, text);
        }

        private static void Print(string[] textList)
        {
            if (textList.IsNullOrEmpty()) throw new System.Exception("Text list handed for printing is null or empty.");
            
            foreach (string text in textList)
                Console.Log(ConCat.Narrative, text);
        }
        
        public static void Default()
        {
            string text = StoryHandler.GetText();
            Print(text);
            rewriter.Rewrite(text);
        }
        
        public static void IdentifyOption(string textID)
        {
            string text = StoryHandler.GetOptionText(textID);
            Print(text);
            rewriter.Rewrite(text);
        }
        
        public static void SelectOption(string textID)
        {
            int optionID = StoryHandler.GetOptionIndex(textID);
            StoryHandler.Choose(optionID);
            Print(StoryHandler.GetPathText());
            rewriter.Rewrite(StoryHandler.GetPathText());
            
            LocationAnimator.TriggerAnimation(textID);
        }
    }
}