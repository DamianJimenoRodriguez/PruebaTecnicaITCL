using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI TimeRemainingText;
    [SerializeField] private TextMeshProUGUI winMessageText;
    [SerializeField] private TextMeshProUGUI loseMessageText;
    [SerializeField] private Level level;
    [SerializeField] private Timer timer;

    private void Awake()
    {
        level.OnPlayerScore += UpdateScoreText;
        timer.OnTick += UpdateTimeRemainingText;
        level.OnPlayerWin += WinMessage;
        level.OnPlayerLose += LoseMessage;
    }

    private void LoseMessage(int coinsRemaining)
    {
        loseMessageText.text = $"Time is up!\nYou missed {coinsRemaining} coins";
    }

    private void WinMessage(LevelTimeData timedata)
    {
        if (timedata != null)
        {
            string message = $"You win!\r\nYour time: {timedata.currentTime.ToString("0:00.00")}\nCurrent Best Time: {timedata.currentRecord.ToString("0:00.00")}";
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

    private void UpdateScoreText(int currentScore)
    {
        scoreText.text = currentScore.ToString();
    }
}