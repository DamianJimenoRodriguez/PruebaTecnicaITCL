using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInputUIButtons : MonoBehaviour, ICameraInput
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

    public void LessZoom()
    {
        Zoom = 1;
    }

    public void MoreZoom()
    {
        Zoom = -1;
    }

    public void StopZooming()
    {
        Zoom = 0;
    }
}