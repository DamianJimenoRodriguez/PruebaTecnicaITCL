using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Orbiting : MonoBehaviour
{
    [SerializeField] private Transform Pivot;

    private Quaternion DestRot = Quaternion.identity;

    [SerializeField] private float PivotDistance = 5f;
    [SerializeField] private float MaxPivotDistance = 1f;
    [SerializeField] private float MinPivotDistance = 10f;
    [SerializeField] private float zoomSpeed = 2;
    [SerializeField] private float RotSpeed = 10f;
    private float RotX = 0f;
    private float RotY = 0f;

    [SerializeField] private float RotXMax = 14;
    [SerializeField] private float RotXMin = -14;
    private ICameraInput input;
    private CameraControlSetUp cameraControlSetUp;

    private void Awake()
    {
        cameraControlSetUp = GetComponent<CameraControlSetUp>();
        input = cameraControlSetUp.GetControlType();
        RotX = transform.rotation.eulerAngles.x;
        RotY = transform.rotation.eulerAngles.y;
    }

    private void Update()
    {
        Zoom(input.Zoom);
        Orbit(input.Horizontal, input.Vertical);
    }

    private void Zoom(float zoomValue)
    {
        PivotDistance += zoomValue * Time.deltaTime * zoomSpeed;
        PivotDistance = Mathf.Clamp(PivotDistance, MinPivotDistance, MaxPivotDistance);
    }

    public void Orbit(float Horz, float Vert)
    {
        RotX += Vert * Time.deltaTime * RotSpeed;
        RotX = Mathf.Clamp(RotX, RotXMin, RotXMax);

        RotY -= Horz * Time.deltaTime * RotSpeed;

        Quaternion YRot = Quaternion.Euler(0f, RotY, 0f);
        DestRot = YRot * Quaternion.Euler(RotX, 0f, 0f);

        transform.rotation = DestRot;

        transform.position = Pivot.position + transform.rotation * Vector3.forward * -PivotDistance;
    }
}