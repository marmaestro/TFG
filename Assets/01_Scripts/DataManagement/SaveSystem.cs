using System;
using TFG.Data;
using TFG.NavigationSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace TFG.DataManagement
{
    [Serializable]
    public class SaveSystem
    {
        [FormerlySerializedAs("playerData")] public GameData gameData;

        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }

        public void LoadFromJson(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }

        [Serializable]
        public struct GameData
        {
            internal City city;
            internal Player player;
            internal string story;
        }
    }

    public interface ISaveableData
    {
        void PopulateSaveData(SaveSystem data);
        void LoadFromSaveData(SaveSystem data);
    }
}