using System;
using System.Collections.Generic;
using UnityEngine;

namespace TFG.SaveSystem
{
    [Serializable]
    public class SaveSystem
    {
        public PlayerData playerData;

        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }

        public void LoadFromJson(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }

        [Serializable]
        public struct PlayerData
        {
            public Transform playerTransform;

            public string currentSection;

            //public List<Task> tasks;
            public List<string> discoveredSections;
        }
    }

    public interface ISaveableData
    {
        void PopulateSaveData(SaveSystem saveData);
        void LoadFromSaveData(SaveSystem saveData);
    }
}