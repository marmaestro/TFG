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

        #region Story Events
        public void ProgressStory()
        {
            while (story.canContinue)
            {
                DialogueBridge.IdentifyOption(Step());
                
                /*if (story.currentChoices.Count <= 0)
                {
                    GetChoices();
                    break;
                }*/
            }
        }

        public static string Step()
        {
            return story.Continue();
        }

        public static void Choose(int choice)
        {
            story.ChooseChoiceIndex(choice);
        }
        #endregion
        
        #region Story Handling
        public static int GetOptionIndex(string textID)
        {
            foreach (Choice choice in story.currentChoices.
                         Where(choice => choice.pathStringOnChoice.Equals(textID)))
                return choice.index;
            return -1;
        }
        
        public static string GetText()
        {
            return story.currentText;
        }
        #endregion

        public static string GetDiary()
        {
            string diaryContent = "";
            while (story.canContinue &&
                   story.path.lastComponent.name.Equals("endDiary"))
                diaryContent += story.Continue();
            
            return diaryContent;
        }
    }
}