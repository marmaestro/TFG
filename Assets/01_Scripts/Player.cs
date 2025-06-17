using System;

namespace TFG
{
    [Serializable]
    public class Player
    {
        private const int baseSteps = 7;
        public int steps = 7;
        public static int location = 0;

        public void Reset()
        {
            steps = baseSteps;
            location = 0;
        }

        public void Visit(int destination)
        {
            steps--;
        }

        public void GoHome()
        {
            Reset();
        }
    }
}