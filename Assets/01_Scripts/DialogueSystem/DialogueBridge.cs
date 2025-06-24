namespace TFG.DialogueSystem
{
    public static class DialogueBridge
    {
        public static void IdentifyOption(string textID)
        {
            int optionID = StoryHandler.GetOptionIndex(textID);
            StoryHandler.Choose(optionID);
            Rewriter.Rewrite(StoryHandler.Step());
        }
    }
}