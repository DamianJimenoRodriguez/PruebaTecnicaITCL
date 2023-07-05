using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System.Runtime.CompilerServices;

public class Level : MonoBehaviour
{
    [SerializeField] private int levelId;
    [SerializeField] private Timer timer;
    [SerializeField] private GameEnd gameEnd;
    private int targetNumberOfCoins;
    private int currentNumberOfCoinsOnPlayer = 0;
    private int numberOfCoinsStored = 0;

    public System.Action<int> OnPlayerScore;

    private void Start()
    {
        targetNumberOfCoins = FindObjectsOfType<Coin>().Length;
        timer.OnTimerEnd += TimeUp;
    }

    private void TimeUp()
    {
        Time.timeScale = 0.0f;
        int remainingCoins = targetNumberOfCoins - numberOfCoinsStored;
        gameEnd.Defeat(remainingCoins);
    }

    private void AllCoinsStored()
    {
        Time.timeScale = 0.0f;
        float levelCompletionTime = timer.GetElapsedTime();
        timer.StopTimer();
        gameEnd.Victoy(levelCompletionTime, levelId);
    }

    public void GetCoin()
    {
        currentNumberOfCoinsOnPlayer++;
    }

    public void StoreCoins()
    {
        numberOfCoinsStored += currentNumberOfCoinsOnPlayer;
        currentNumberOfCoinsOnPlayer = 0;
        if (OnPlayerScore != null)
        {
            OnPlayerScore(numberOfCoinsStored);
        }
        if (numberOfCoinsStored >= targetNumberOfCoins)
        {
            AllCoinsStored();
        }
    }
}