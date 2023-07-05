using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// classes used to save player data by using JSONutility
/// </summary>

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