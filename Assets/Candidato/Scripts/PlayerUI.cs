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

    private void Awake()
    {
        player.OnPlayerScore += UpdateScoreText;
    }

    private void UpdateScoreText(int currentScore)
    {
        scoreText.text = currentScore.ToString();
    }
}