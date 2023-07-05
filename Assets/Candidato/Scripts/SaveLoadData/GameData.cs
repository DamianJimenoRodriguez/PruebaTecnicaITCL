using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public LevelData[] levelsData;
}

[Serializable]
public class LevelData
{
    public int levelId;
    public float bestLevelTime;
}