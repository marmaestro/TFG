using Ink.Runtime;
using UnityEngine;

namespace TFG.DialogueSystem
{
    public class StoryTracker
    {
        internal Story story;

        public StoryTracker(TextAsset mainText)
        {
            story = new Story(mainText.text);
        }

        public string SaveStory()
        {
            return story.state.ToJson();
        }

        public void LoadStory(string savedJson)
        {
            story.state.LoadJson(savedJson);
        }
    }
}