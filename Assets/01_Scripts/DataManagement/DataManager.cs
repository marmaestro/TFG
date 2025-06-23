using System.Collections.Generic;
using UnityEngine;

namespace TFG.DataManagement
{
    public static class DataManager
    {
        public static void SaveJsonData(IEnumerable<ISaveableData> saveables)
        {
            if (saveables == null) return;

            SaveSystem data = new();
            foreach (ISaveableData saveable in saveables) saveable?.PopulateSaveData(data);

            if (FileManager.WriteToFile("SaveData.dat", data.ToJson()))
                Debug.Log("Save successful");
        }

        public static void LoadJsonData(IEnumerable<ISaveableData> saveables)
        {
            if (FileManager.LoadFromFile("SaveData.dat", out string json))
            {
                SaveSystem sd = new();
                sd.LoadFromJson(json);

                foreach (ISaveableData saveable in saveables) saveable.LoadFromSaveData(sd);

                Debug.Log("Load complete");
            }
        }
    }
}