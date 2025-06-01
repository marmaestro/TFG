using System;
using System.IO;
using TFG.ExtensionMethods;
using UnityEngine;
using Console = TFG.ExtensionMethods.Console;

namespace TFG.SaveSystem
{
    public static class FileManager
    {
        public static bool Exists(string fileName)
        {
            string fullPath = Path.Combine(Application.persistentDataPath, fileName);
            
            try
            {
                File.OpenRead(fullPath).Close();
                return true;
            }

            catch (Exception e)
            {
#if DEBUG
                Console.LogError(ConsoleCategories.DataLoading, $"Failed to open {fileName} with exception {e}.");
#endif
                return false;
            }
        }
        
        public static bool WriteToFile(string fileName, string fileContents)
        {
            string fullPath = Path.Combine(Application.persistentDataPath, fileName);

            try
            {
                File.WriteAllText(fullPath, fileContents);
#if DEBUG
                Console.Log(ConsoleCategories.DataLoading, $"Data written to {fullPath} successfully.");
#endif
                return true;
            }

            catch (Exception e)
            {
#if DEBUG
                Console.LogError(ConsoleCategories.DataLoading, $"Failed to write to {fullPath} with exception {e}.");
#endif
                return false;
            }
        }
        
        public static void WriteToPictureFile(string filePath, string fileName, byte[] fileContents)
        {
            string fullPath = Path.Combine(Application.persistentDataPath, filePath, fileName);

            try
            {
                File.WriteAllBytes(fullPath, fileContents);
#if DEBUG
                Console.Log(ConsoleCategories.DataLoading, $"Image written to {fullPath} successfully.");
#endif
            }

            catch (Exception e)
            {
#if DEBUG
                Console.LogError(ConsoleCategories.DataLoading, $"Failed to write image to {fullPath} with exception {e}.");
#endif
            }
        }

        public static bool LoadFromFile(string fileName, out string result)
        {
            string fullPath = Path.Combine(Application.persistentDataPath, fileName);

            try
            {
                result = File.ReadAllText(fullPath);
#if DEBUG
                Console.Log(ConsoleCategories.DataLoading, $"Data read from {fullPath} successfully.");
#endif
                return true;
            }

            catch (Exception e)
            {
#if DEBUG
                Console.LogError(ConsoleCategories.DataLoading, $"Failed to read data from {fullPath} with exception {e}.");
#endif
                
                result = "";
                return false;
            }
        }

        public static bool LoadGraphFromFile(TextAsset json, out int[][] result)
        {
            try
            {
                result = JsonUtility.FromJson<int[][]>(json.text);
#if DEBUG
                Console.Log(ConsoleCategories.DataLoading, $"Graph {json.name} read successfully.");
#endif
                return true;
            }

            catch (Exception e)
            {
#if DEBUG
                Console.LogError(ConsoleCategories.DataLoading, $"Failed to read graph {json.name} with exception {e}.");
#endif
                
                result = Array.Empty<int[]>();
                return false;
            }
        }
        
        public static bool LoadScenesFromFile(TextAsset json, out string[] result)
        {
            try
            {
                result = JsonUtility.FromJson<string[]>(json.text);
#if DEBUG
                Console.Log(ConsoleCategories.DataLoading, $"Scene name list {json.name} read successfully.");
#endif
                return true;
            }

            catch (Exception e)
            {
#if DEBUG
                Console.LogError(ConsoleCategories.DataLoading, $"Failed to read scene list {json.name} with exception {e}.");
#endif
                
                result = Array.Empty<string>();
                return false;
            }
        }
    }
}