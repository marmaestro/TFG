using System;
using UnityEngine.Serialization;

namespace TFG
{
    [Serializable]
    public class Player
    {
        private const int baseSteps = 5; // full game steps : 7
        public int steps = 5;
        [FormerlySerializedAs("currentPlayerLocation")] public int location;

        public void Reset()
        {
            steps = baseSteps;
            location = 0;
        }

        public void Move()
        {
            steps--;
        }
    }
}