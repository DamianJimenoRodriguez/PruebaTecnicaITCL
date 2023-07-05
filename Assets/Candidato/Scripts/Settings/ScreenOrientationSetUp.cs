using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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