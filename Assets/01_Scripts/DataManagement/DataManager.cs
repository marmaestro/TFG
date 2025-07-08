using System.Collections.Generic;
using EasyTextEffects.Editor.MyBoxCopy.Extensions;
using JetBrains.Annotations;
using UnityEngine;

namespace TFG.DataManagement
{
    public static class DataManager
    {
        public static void SaveJsonData([NotNull] IEnumerable<ISaveableData> saveables)
        {
            SaveSystem data = new();
            saveables.ForEach(s => s?.PopulateSaveData(data));

            if (FileManager.WriteToFile("SaveData.dat", data.ToJson()))
                Debug.Log("Save successful");
        }

        public static void LoadJsonData(IEnumerable<ISaveableData> saveables)
        {
            if (FileManager.LoadFromFile("SaveData.dat", out string json))
            {
                SaveSystem sd = new();
                sd.LoadFromJson(json);
                
                saveables.ForEach(s => s?.LoadFromSaveData(sd));

                Debug.Log("Load complete");
            }
        }
    }
}