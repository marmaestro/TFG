using System;
using UnityEngine;

namespace TFG.NavigationSystem
{
    [Serializable]
    [CreateAssetMenu(fileName = "City", menuName = "SIL/City")]
    public class City : ScriptableObject
    {
        [SerializeField] private Graph graph;

        internal bool[] visitedLocations;
        internal string[] scenes => graph.nodeNames;

        public void Awake()
        {
            visitedLocations = new bool[graph.NodeCount];
        }

        public int[] VisitableLocations() => graph.AvailableNodes();
        
        public bool Visited(int nodeID) => visitedLocations[nodeID];
    }
}