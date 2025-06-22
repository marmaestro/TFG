using System;
using TFG.Navigation;
using UnityEngine;

namespace TFG.DataManagement
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
            internal City city;
            internal Player player;
        }
    }

    public interface ISaveableData
    {
        void PopulateSaveData(SaveSystem saveData);
        void LoadFromSaveData(SaveSystem saveData);
    }
}