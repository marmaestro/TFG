using System;

namespace TFG
{
    [Serializable]
    public class Player
    {
        private const int baseSteps = 7;
        public int steps = 7;
        public static int location = 1;

        public void Reset()
        {
            steps = baseSteps;
        }

        public void Visit(int destination)
        {
            steps--;
            location = destination;
        }
    }
}