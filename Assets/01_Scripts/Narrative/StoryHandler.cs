using System.Collections.Generic;
using System.Linq;
using Ink.Runtime;
using UnityEngine;

namespace TFG.Narrative
{
    public class StoryHandler
    {
        private static Story story;

        public StoryHandler(TextAsset mainText)
        {
            story = new Story(mainText.text);
        }

        #region Save and Load
        public string SaveStory()
        {
            return story.state.ToJson();
        }

        public void LoadStory(string savedJson)
        {
            story.state.LoadJson(savedJson);
        }
        #endregion
        
        #region Story Handling
        public static void StartStorySection(string knotName)
        {
            story.ChoosePathString(knotName);
            TextBridge.Default();
        }
        
        public static void Choose(int choice)
        {
            story.ChooseChoiceIndex(choice);
        }
        
        public static string GetText()
        {
            return story.currentText;
        }
        
        public static string GetOptionText(string textID)
        {
            foreach (Choice choice in story.currentChoices.
                         Where(choice => choice.pathStringOnChoice.Equals(textID)))
                return choice.text;
            return GetText();
        }
        
        public static int GetOptionIndex(string textID)
        {
            if (int.TryParse(textID, out int n)) return n;
            
            foreach (Choice choice in story.currentChoices.
                         Where(choice => choice.pathStringOnChoice.Equals(textID)))
                return choice.index;
            return -1;
        }
        
        public static string[] GetPathText()
        {
            List<string> textList = new();
            
            while (story.canContinue)
                textList.Add(story.Continue());

            return textList.ToArray();
        }
        
        public static string GetDiary()
        {
            string diaryContent = "";
            while (story.canContinue &&
                   story.path.lastComponent.name.Equals("endDiary"))
                diaryContent += story.Continue();
            
            return diaryContent;
        }
        #endregion
        
    }
}