using System;
using TFG.Graphs;
using TFG.SaveSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using static TFG.Player;

namespace TFG.Navigation
{
    [Serializable]
    [CreateAssetMenu(fileName = "City", menuName = "SIL/City")]
    public class City : ScriptableObject
    {
        [SerializeField] private TextAsset graphFile;
        [SerializeField] private TextAsset scenesFile;
        
        internal int home = 0;

        public static Graph city;
        internal static bool[] visitedLocations;
        internal static string[] scenes;

        public void Awake()
        {
            city = new Graph(graphFile);
            FileManager.LoadScenesFromFile(scenesFile, out string[] data);
            scenes = data;
            visitedLocations = new bool[city.NodeCount];
        }
    }
}