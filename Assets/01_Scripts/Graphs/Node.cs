using System;
using UnityEngine;

namespace TFG.Graphs
{
    [Serializable]
    [CreateAssetMenu(fileName = "Node", menuName = "SIL/Graphs/Node")]
    internal class Node : ScriptableObject
    {
        [SerializeField] private int[] edges;
        public int[] Edges => edges;

        private int visited;
        public int Visited => visited;

        public Node(int[] edges)
        {
            this.edges = edges;
            visited = 0;
        }

        public void Visit()
        {
            visited++;
        }
    }
}