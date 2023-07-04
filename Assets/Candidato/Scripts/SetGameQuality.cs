using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameQuality : MonoBehaviour
{
    public void SetQualityByIndex(int index)
    {
        QualitySettings.SetQualityLevel(index, false);
    }
}