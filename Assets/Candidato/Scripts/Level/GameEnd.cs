using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private Timer timer;

    public System.Action<int> OnPlayerLose;
    public System.Action<LevelCompletionTimeData> OnPlayerWin;

    public void Defeat(int remainingCoins)
    {
        if (OnPlayerLose != null)
        {
            OnPlayerLose(remainingCoins);
        }
        Time.timeScale = 0.0f;
        loseScreen.SetActive(true);
    }

    public void Victoy(float levelCompletionTime, int levelId)
    {
        winScreen.SetActive(true);
        Time.timeScale = 0.0f;
        if (OnPlayerWin != null)
        {
            LevelCompletionTimeData timeData = CheckForNewRecord(levelCompletionTime, levelId);
            OnPlayerWin(timeData);
        }
    }

    private LevelCompletionTimeData CheckForNewRecord(float levelCompletionTime, int levelId)
    {
        GameData data = DataHandler.LoadFromFile();
        for (int i = 0; i < data.levelsData.Length; i++)
        {
            if (data.levelsData[i].levelId == levelId)
            {
                LevelCompletionTimeData timeData = new LevelCompletionTimeData();
                timeData.currentRecord = data.levelsData[i].bestLevelTime;
                timeData.currentTime = levelCompletionTime;

                if (data.levelsData[i].bestLevelTime > levelCompletionTime)
                {
                    data.levelsData[i].bestLevelTime = levelCompletionTime;
                    timeData.newRecord = true;
                    DataHandler.SaveToFile(data);
                    return timeData;
                }
                else
                {
                    timeData.newRecord = false;
                    return timeData;
                }
            }
        }
        return null;
    }
}

public class LevelCompletionTimeData
{
    public float currentTime;
    public float currentRecord;
    public bool newRecord;
}