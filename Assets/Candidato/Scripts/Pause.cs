using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public void SetTimeScale(float newTimeScale)
    {
        Time.timeScale = newTimeScale;
    }

    private void OnDisable()
    {
        Time.timeScale = 1.0f;
    }
}