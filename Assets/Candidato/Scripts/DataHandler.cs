using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class DataHandler : MonoBehaviour
{
    public GameData DefaultGameData;
    public static string saveName = "gameData";

    private void Start()
    {
        if (!File.Exists(Application.persistentDataPath + "/" + saveName + ".json"))
        {
            SaveToFile(DefaultGameData);
        }
    }

    public static void SaveToFile(GameData gameData)
    {
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(Application.persistentDataPath + "/" + saveName + ".json", json);
        Debug.Log(Application.persistentDataPath + "/" + saveName + ".json");
    }

    public static GameData LoadFromFile()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/" + saveName + ".json");
        GameData loadData = JsonUtility.FromJson<GameData>(json);

        return loadData;
    }
}