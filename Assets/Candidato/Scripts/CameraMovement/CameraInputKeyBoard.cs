using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PC control for the camera
/// uses keyboard keys
/// </summary>
public class CameraInputKeyBoard : MonoBehaviour, ICameraInput
{
    public float Horizontal { get; set; }
    public float Vertical { get; set; }
    public int Zoom { get; set; }

    private KeyCode moreZoomUpKey = KeyCode.E;
    private KeyCode lessZoomKey = KeyCode.Q;

    private void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(moreZoomUpKey))
        {
            Zoom = -1;
        }
        else if (Input.GetKey(lessZoomKey))
        {
            Zoom = 1;
        }
        else
        {
            Zoom = 0;
        }
    }
}