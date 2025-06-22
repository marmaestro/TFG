using System;
using UnityEngine;

namespace TFG.Navigation
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

        public int[] VisitableSpots() => graph.VisitableNodes();
    }
}