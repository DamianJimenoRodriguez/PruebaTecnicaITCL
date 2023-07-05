using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsStoredText;
    [SerializeField] private TextMeshProUGUI coinsOnPlayerText;
    [SerializeField] private TextMeshProUGUI TimeRemainingText;
    [SerializeField] private TextMeshProUGUI winMessageText;
    [SerializeField] private TextMeshProUGUI loseMessageText;
    [SerializeField] private Level level;
    [SerializeField] private GameEnd gameEnd;
    [SerializeField] private Timer timer;

    private void Awake()
    {
        level.OnPlayerPickUpCoin += UpdateCoinsOnPlayerText;
        level.OnPlayerStoreCoins += UpdateCoinsStoredText;
        timer.OnTick += UpdateTimeRemainingText;
        gameEnd.OnPlayerWin += WinMessage;
        gameEnd.OnPlayerLose += LoseMessage;
    }

    private void LoseMessage(int coinsRemaining)
    {
        loseMessageText.text = $"Time is up!\nYou missed {coinsRemaining} coins";
    }

    private void WinMessage(LevelCompletionTimeData timedata)
    {
        if (timedata != null)
        {
            string message = $"Level Complete!\r\nYour time: {timedata.currentTime.ToString("0:00.00")}\nCurrent Best Time: {timedata.currentRecord.ToString("0:00.00")}";
            if (timedata.newRecord)
            {
                winMessageText.text = $"{message}\nNew record!!!";
            }
            else
            {
                winMessageText.text = message;
            }
        }
        else
        {
            winMessageText.text = "You Win!!";
        }
    }

    private void UpdateTimeRemainingText(float timeRemaing)
    {
        TimeRemainingText.text = timeRemaing.ToString("0:00.00");
    }

    private void UpdateCoinsOnPlayerText(int currentScore)
    {
        coinsOnPlayerText.text = currentScore.ToString();
    }

    private void UpdateCoinsStoredText(int coinsStored)
    {
        coinsOnPlayerText.text = "0";
        coinsStoredText.text = coinsStored.ToString();
    }
}