using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that sets the control type based on whether the player
/// is using a Pc or a mobile device
/// </summary>
public class CameraControlSetUp : MonoBehaviour
{
    [SerializeField] private CameraInputUIButtons mobileControls;
    [SerializeField] private CameraInputKeyBoard pcControls;

    public ICameraInput GetControlType()
    {
#if UNITY_ANDROID || UNITY_IOS
        Destroy(pcControls);
        return mobileControls;

#else

        Destroy(mobileControls);
        return pcControls;
#endif
    }
}