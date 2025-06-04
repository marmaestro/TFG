using System;
using TFG.Graphs;
using UnityEngine;
using UnityEngine.Serialization;

namespace TFG.Navigation
{
    [Serializable]
    [CreateAssetMenu(fileName = "City", menuName = "SIL/City")]
    public class City : ScriptableObject
    {
        [FormerlySerializedAs("city")] [SerializeField] private Graph graph;
        
        internal int home = 0;
        
        internal bool[] visitedLocations;
        internal string[] scenes => graph.nodeNames;

        public void Awake()
        {
            visitedLocations = new bool[graph.NodeCount];
        }

        public int[] VisitableSpots() => graph.VisitableNodes();
    }
}