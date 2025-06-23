using System.Collections.Generic;
using System.Linq;
using Ink.Runtime;
using UnityEngine;

namespace TFG.DialogueSystem
{
    public class StoryHandler
    {
        private readonly Story story;

        public StoryHandler(TextAsset mainText)
        {
            story = new Story(mainText.text);
        }

        #region SAVING AND LOADING
        public string SaveStory()
        {
            return story.state.ToJson();
        }

        public void LoadStory(string savedJson)
        {
            story.state.LoadJson(savedJson);
        }
        #endregion

        public void ProgressStory()
        {
            while (story.canContinue)
            {
                DialogueBridge.NewTextLine(Step());
                
                if (story.currentChoices.Count <= 0)
                {
                    GetChoices();
                    break;
                }
            }
        }

        private string Step()
        {
            return story.Continue();
        }

        private List<string> GetChoices()
        {
            return story.currentChoices.Select(c => c.text).ToList();
        }

        private void Choose(int choice)
        {
            story.ChooseChoiceIndex(choice);
        }
    }
}