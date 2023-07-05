using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// script use to set up the screen orientation of the game when playing on a mobile device
/// Is only used in the main menu by two buttons
/// </summary>
public class ScreenOrientationSetUp : MonoBehaviour
{
    public void LandScape()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight;
    }

    public void Portrait()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
}