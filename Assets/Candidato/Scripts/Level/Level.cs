using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System.Runtime.CompilerServices;

/// <summary>
/// Script that keeps track of how many coins the player has
/// informs GameEnd when the player gets all the coins
/// or when the time is up
/// </summary>
public class Level : MonoBehaviour
{
    [SerializeField] private int levelId;
    [SerializeField] private Timer timer;
    [SerializeField] private GameEnd gameEnd;
    private int coinsInLevel;
    private int coinsOnPlayer = 0;
    private int coinsStored = 0;

    public System.Action<int> OnPlayerPickUpCoin;
    public System.Action<int> OnPlayerStoreCoins;

    private void Start()
    {
        coinsInLevel = FindObjectsOfType<Coin>().Length;
        timer.OnTimerEnd += TimeUp;
    }

    public void GetCoin()
    {
        coinsOnPlayer++;
        if (OnPlayerPickUpCoin != null)
        {
            OnPlayerPickUpCoin(coinsOnPlayer);
        }
    }

    public void StoreCoins()
    {
        if (coinsOnPlayer > 0)
        {
            coinsStored += coinsOnPlayer;
            coinsOnPlayer = 0;

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
        gameEnd.Victory(levelCompletionTime, levelId);
    }
}