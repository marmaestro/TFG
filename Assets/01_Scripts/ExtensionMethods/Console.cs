using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace TFG.ExtensionMethods
{
    #if DEBUG
    public static class Console
    {
        [Conditional("DEBUG")]
        public static void Log(string category, string message)
        {
            Debug.Log(Format(category, message));
        }

        [Conditional("DEBUG")]
        public static void LogWarning(string category, string message)
        {
            Debug.LogWarning(Format(category, message));
        }

        [Conditional("DEBUG")]
        public static void LogError(string category, string message)
        {
            Debug.LogError(Format(category, message));
        }
        
        private static string Format(string category, string message)
        {
            return $"<b>[{category}]</b> {message}";
        }
    }
    #endif
}