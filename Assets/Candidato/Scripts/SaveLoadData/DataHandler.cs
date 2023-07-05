using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

/// <summary>
/// Class used to save the best completion time in each level
/// it uses JsonUtility.
/// We store the data using Application.persistentDataPath
/// to make sure it works both in pc and mobile devices.
/// Also, it check if the data file is not created,
/// if so it creates it with default data
/// </summary>
public class DataHandler : MonoBehaviour
{
    public GameData DefaultGameData;
    public static string saveName = "gameData";

    private void Start()
    {
        if (!File.Exists(Application.persistentDataPath + "/" + saveName + ".json"))
        {
            ResetDataToDefault();
        }
    }

    public void ResetDataToDefault()
    {
        SaveToFile(DefaultGameData);
    }

    public static void SaveToFile(GameData gameData)
    {
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(Application.persistentDataPath + "/" + saveName + ".json", json);
    }

    public static GameData LoadFromFile()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/" + saveName + ".json");
        GameData loadData = JsonUtility.FromJson<GameData>(json);

        return loadData;
    }
}