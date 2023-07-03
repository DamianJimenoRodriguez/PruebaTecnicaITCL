using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI TimeRemainingText;
    [SerializeField] private Player player;
    [SerializeField] private Timer timer;

    private void Awake()
    {
        player.OnPlayerScore += UpdateScoreText;
        timer.OnTick += UpdateTimeRemainingText;
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