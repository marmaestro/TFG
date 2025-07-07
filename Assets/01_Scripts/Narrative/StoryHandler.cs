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
        
        #region Get Text
        public static string GetLine()
        {
            return story.currentText;
        }

        public static string Step()
        {
            return story.Continue();
        }
        
        public static string GetDiary()
        {
            story.ChoosePathString("diary");
            string diaryContent = "";
            while (story.canContinue)
                diaryContent += story.Continue();
            
            return diaryContent;
        }
        #endregion
        
        #region Flow Handling
        public static bool canContinue => story.canContinue;
        
        public static void StartStorySection(string knotName)
        {
            story.ChoosePathString(knotName);
            story.Continue();
            TextBridge.CurrentLine();
        }
        #endregion
        
        #region Branching Methods
        public static void Choose(int choice)
        {
            story.ChooseChoiceIndex(choice);
            story.Continue();
        }
        
        public static string GetOptionText(string textID)
        {
            foreach (Choice choice in story.currentChoices.Where(choice => choice.tags[0].Equals(textID)))
                return choice.text;
            return GetLine();
        }
        
        public static int GetOptionIndex(string textID)
        {
            foreach (Choice choice in story.currentChoices.Where(choice => choice.tags[0].Equals(textID)))
                return choice.index;
            return -1;
        }
        #endregion
    }
}