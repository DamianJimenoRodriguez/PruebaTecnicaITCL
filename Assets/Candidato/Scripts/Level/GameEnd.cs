using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script used when the player wins the game (gets all the coins before time runs out)
/// or when the player loses (the opposite happens)
/// it shows the player a win screen or a lose screen acordingly
/// also, for the win screen check whether the player got a new record or not
/// </summary>
public class GameEnd : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;

    public System.Action<int> OnPlayerLose;
    public System.Action<LevelCompletionTimeData> OnPlayerWin;

    public void Defeat(int remainingCoins)
    {
        if (OnPlayerLose != null)
        {
            OnPlayerLose(remainingCoins);
        }

        loseScreen.SetActive(true);
    }

    public void Victory(float levelCompletionTime, int levelId)
    {
        winScreen.SetActive(true);

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