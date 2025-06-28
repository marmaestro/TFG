using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace TFG.Navigation
{
    [Serializable]
    [CreateAssetMenu(fileName = "Node", menuName = "SIL/Graphs/Node")]
    public class NodeData : ScriptableObject
    {
        [FormerlySerializedAs("sceneName")] [SerializeField] public string SceneName;
        [FormerlySerializedAs("edges")] [SerializeField] public int[] Edges;

        public NodeData(int[] edges)
        {
            this.Edges = edges;
        }
    }
}