using System;
using TFG.Graphs;
using UnityEngine;

namespace TFG.Navigation
{
    [Serializable]
    [CreateAssetMenu(fileName = "City", menuName = "SIL/City")]
    public class City : ScriptableObject
    {
        [SerializeField] private Graph city;
        
        internal int home = 0;
        
        internal bool[] visitedLocations;
        internal string[] scenes;

        public void Awake()
        {
            scenes = city.nodeNames;
            visitedLocations = new bool[city.NodeCount];
        }

        public int[] VisitableSpots() => city.VisitableNodes();
    }
}