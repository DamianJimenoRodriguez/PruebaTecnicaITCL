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
    private int coinsInLevel;
    private int currentNumberOfCoinsOnPlayer = 0;
    private int coinsStored = 0;

    public System.Action<int> OnPlayerPickUpCoin;
    public System.Action<int> OnPlayerStoreCoins;

    private void Start()
    {
        coinsInLevel = FindObjectsOfType<Coin>().Length;
        timer.OnTimerEnd += TimeUp;
    }

    private void TimeUp()
    {
        Time.timeScale = 0.0f;
        int remainingCoins = coinsInLevel - coinsStored;
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
        if (OnPlayerPickUpCoin != null)
        {
            OnPlayerPickUpCoin(currentNumberOfCoinsOnPlayer);
        }
    }

    public void StoreCoins()
    {
        if (currentNumberOfCoinsOnPlayer > 0)
        {
            coinsStored += currentNumberOfCoinsOnPlayer;
            currentNumberOfCoinsOnPlayer = 0;

            if (OnPlayerStoreCoins != null)
            {
                OnPlayerStoreCoins(coinsStored);
            }

            if (coinsStored >= coinsInLevel)
            {
                AllCoinsStored();
            }
        }
    }
}