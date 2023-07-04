using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInputUIButtons : MonoBehaviour, CameraInput
{
    public float Horizontal { get; set; }
    public float Vertical { get; set; }
    public int Zoom { get; set; }

    public void Rigth()
    {
        Horizontal = 1;
    }

    public void Left()
    {
        Horizontal = -1;
    }

    public void Up()
    {
        Vertical = 1;
    }

    public void Down()
    {
        Vertical = -1;
    }

    public void NoHorizontal()
    {
        Horizontal = 0;
    }

    public void NoVertical()
    {
        Vertical = 0;
    }

    public void ZoomUp()
    {
        Zoom = 1;
    }

    public void ZoomDown()
    {
        Zoom = -1;
    }

    public void NoZoom()
    {
        Zoom = 0;
    }
}