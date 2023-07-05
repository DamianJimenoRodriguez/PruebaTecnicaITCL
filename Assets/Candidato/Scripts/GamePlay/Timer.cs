using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float countDownTime = 60f;
    [SerializeField] private bool isTicking;

    private float remainingTime;

    public System.Action<float> OnTick;
    public System.Action OnTimerEnd;

    private void Awake()
    {
        remainingTime = countDownTime;
    }

    public void StopTimer()
    {
        isTicking = false;
    }

    public float GetElapsedTime()
    {
        return countDownTime - remainingTime;
    }

    private void Update()
    {
        if (isTicking)
        {
            Tick();
        }
    }

    public void Tick()
    {
        remainingTime -= Time.deltaTime;
        if (remainingTime > 0)
        {
            if (OnTick != null)
            {
                OnTick(remainingTime);
            }
        }
        else
        {
            if (OnTick != null)
            {
                OnTick(0);
            }
            if (OnTimerEnd != null)
            {
                OnTimerEnd();
            }
            isTicking = false;
        }
    }
}