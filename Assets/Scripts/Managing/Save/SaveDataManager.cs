using System.Collections.Generic;
using UnityEngine;

public static class SaveDataManager
{
    public static void SaveJsonData(IEnumerable<ISaveable> saveables)
    {
        SaveData sd = new();
        foreach (ISaveable saveable in saveables)
        {
            saveable.PopulateSaveData(sd);
        }

        if (FileManager.WriteToFile("SaveData01.dat", sd.ToJson()))
        {
            Debug.Log("Save successful");
        }
    }
    
    public static void LoadJsonData(IEnumerable<ISaveable> saveables)
    {
        if (FileManager.LoadFromFile("SaveData01.dat", out string json))
        {
            SaveData sd = new();
            sd.LoadFromJson(json);

            foreach (ISaveable saveable in saveables)
            {
                saveable.LoadFromSaveData(sd);
            }
            
            Debug.Log("Load complete");
        }
    }
}
