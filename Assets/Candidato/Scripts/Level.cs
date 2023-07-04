using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Level : MonoBehaviour
{
    [SerializeField] private int levelId;
    [SerializeField] private Timer timer;

    private int targetNumberOfCoins;
    private int currentNumberOfCoins;

    private int CurrentScore = 0;
    public System.Action<int> OnPlayerScore;

    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;

    public System.Action<int> OnPlayerLose;
    public System.Action<LevelTimeData> OnPlayerWin;

    private void Start()
    {
        targetNumberOfCoins = FindObjectsOfType<Coin>().Length;
        timer.OnTimerEnd += GameOver;
    }

    private void GameOver()
    {
        if (OnPlayerLose != null)
        {
            int remainingCoins = targetNumberOfCoins - currentNumberOfCoins;
            OnPlayerLose(remainingCoins);
        }
        Time.timeScale = 0.0f;
        loseScreen.SetActive(true);
    }

    private void Victoy()
    {
        float levelCompletionTime = timer.GetElapsedTime();

        timer.StopTimer();
        winScreen.SetActive(true);

        if (OnPlayerWin != null)
        {
            LevelTimeData timeData = CheckForNewRecord(levelCompletionTime);
            OnPlayerWin(timeData);
        }
    }

    private LevelTimeData CheckForNewRecord(float levelCompletionTime)
    {
        GameData data = DataHandler.LoadFromFile();
        for (int i = 0; i < data.levelsData.Length; i++)
        {
            if (data.levelsData[i].levelId == levelId)
            {
                LevelTimeData timeData = new LevelTimeData();
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

    public void AddScore(int scoreToAdd)
    {
        CurrentScore += scoreToAdd;
        if (OnPlayerScore != null)
        {
            OnPlayerScore(CurrentScore);
        }
        currentNumberOfCoins++;
        if (currentNumberOfCoins == targetNumberOfCoins)
        {
            Victoy();
        }
    }
}

public class LevelTimeData
{
    public float currentTime;
    public float currentRecord;
    public bool newRecord;
}