using UnityEngine;
using UnityEngine.SceneManagement;

namespace TFG.Graphs
{
    [CreateAssetMenu(fileName = "City", menuName = "SIL/City")]
    public class City : ScriptableObject
    {
        [SerializeField] private Object graphFile;
        [SerializeField] internal Scene[] scenes;

        private int home = 0;
        private int currentLocation = 0;
        public string CurrentLocation => scenes[currentLocation].name;

        private Graph city;
        private bool[] visitedLocations;

        public void Awake()
        {
            city = new Graph($"{graphFile.name}.json");
            visitedLocations = new bool[city.NodeCount];
        }
    }
}