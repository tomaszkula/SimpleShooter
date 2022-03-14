using System.IO;
using UnityEngine;

public static class SS_SaveSystem
{
    public const string SAVE_FILE_NAME = "save.json";
    public static readonly string SAVE_FILE_PATH = $"{Application.persistentDataPath}/{SAVE_FILE_NAME}";

    public static SS_SaveData SaveData = null;

    public static void Load()
    {
        if(File.Exists(SAVE_FILE_PATH) == false)
        {
            SaveData = new SS_SaveData();
            return;
        }

        string _saveData = File.ReadAllText(SAVE_FILE_PATH);
        SaveData = JsonUtility.FromJson<SS_SaveData>(_saveData);
    }

    public static void Save()
    {
        string _saveData = JsonUtility.ToJson(SaveData);
        File.WriteAllText(SAVE_FILE_PATH, _saveData);
    }
}
