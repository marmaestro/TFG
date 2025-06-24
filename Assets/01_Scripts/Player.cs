using System;

namespace TFG
{
    [Serializable]
    public class Player
    {
        private const int baseSteps = 5; // full game steps : 7
        public int steps = 5;
        public static int locationID;

        public void Reset()
        {
            steps = baseSteps;
            locationID = 0;
        }

        public void Move()
        {
            steps--;
        }
    }
}