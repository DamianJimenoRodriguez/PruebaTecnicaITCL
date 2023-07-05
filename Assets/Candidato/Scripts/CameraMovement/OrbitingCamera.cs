using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class OrbitingCamera : MonoBehaviour
{
    [SerializeField] private Transform orbitingObject;
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
        RotX = orbitingObject.rotation.eulerAngles.x;
        RotY = orbitingObject.rotation.eulerAngles.y;
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

        orbitingObject.rotation = DestRot;

        orbitingObject.position = Pivot.position + orbitingObject.rotation * Vector3.forward * -PivotDistance;
    }
}