using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int CurrentScore = 0;
    public System.Action<int> OnPlayerScore;

    public void AddScore(int scoreToAdd)
    {
        CurrentScore += scoreToAdd;
        if (OnPlayerScore != null)
        {
            OnPlayerScore(CurrentScore);
        }
    }
}