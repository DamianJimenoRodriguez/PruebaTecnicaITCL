using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level : MonoBehaviour
{
    [SerializeField] private Timer timer;

    private int targetNumberOfCoins;
    private int currentNumberOfCoins;

    private int CurrentScore = 0;
    public System.Action<int> OnPlayerScore;

    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;

    public System.Action<int> OnPlayerLose;
    public System.Action<float> OnPlayerWin;

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
        if (OnPlayerWin != null)
        {
            OnPlayerWin(timer.GetElapsedTime());
        }
        timer.StopTimer();
        winScreen.SetActive(true);
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