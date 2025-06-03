using System.Collections.Generic;
using UnityEngine;

namespace TFG.DataManagement
{
    public static class DataManager
    {
        public static void SaveJsonData(IEnumerable<ISaveableData> saveables)
        {
            if (saveables == null) return;
            
            SaveSystem sd = new();
            foreach (ISaveableData saveable in saveables) saveable?.PopulateSaveData(sd);

            if (FileManager.WriteToFile("SaveData01.dat", sd.ToJson())) Debug.Log("Save successful");
        }

        public static void LoadJsonData(IEnumerable<ISaveableData> saveables)
        {
            if (FileManager.LoadFromFile("SaveData01.dat", out string json))
            {
                SaveSystem sd = new();
                sd.LoadFromJson(json);

                foreach (ISaveableData saveable in saveables) saveable.LoadFromSaveData(sd);

                Debug.Log("Load complete");
            }
        }
    }
}