using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICameraInput
{
    float Horizontal { get; set; }
    float Vertical { get; set; }
    int Zoom { get; set; }
}