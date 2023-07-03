using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInputKeyBoard : MonoBehaviour, CameraInput
{
    public float Horizontal { get; set; }
    public float Vertical { get; set; }
    public int Zoom { get; set; }

    [SerializeField] private KeyCode zoomUpKey;
    [SerializeField] private KeyCode zoomDownKey;

    private void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(zoomUpKey))
        {
            Zoom = 1;
            Debug.Log("Positivezoom");
        }
        else if (Input.GetKey(zoomDownKey))
        {
            Zoom = -1;
            Debug.Log("negativezoom");
        }
        else
        {
            Zoom = 0;
            Debug.Log("nozoom");
        }
    }
}