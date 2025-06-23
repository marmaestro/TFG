namespace TFG.DialogueSystem
{
    public static class DialogueBridge
    {
        private static Rewriter rewriter;
        
        public static void NewTextLine(string text)
        {
            Rewriter.Rewrite(text);
        }
    }
}