using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Orbiting : MonoBehaviour
{
    public Transform Pivot;

    private Quaternion DestRot = Quaternion.identity;

    public float PivotDistance = 5f;
    public float MaxPivotDistance = 1f;
    public float MinPivotDistance = 10f;

    public float zoomSpeed = 2;

    public float RotSpeed = 10f;
    private float RotX = 0f;
    private float RotY = 0f;

    [SerializeField] private float RotXMax = 14;
    [SerializeField] private float RotXMin = -14;

    private void Awake()
    {
        RotX = transform.rotation.eulerAngles.x;
        RotY = transform.rotation.eulerAngles.y;
    }

    private void Update()
    {
        float Horz = Input.GetAxis("Horizontal");
        float Vert = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.Z))
        {
            Zoom(1);
        }
        else if (Input.GetKey(KeyCode.X))
        {
            Zoom(-1);
        }
        Orbit(Horz, Vert);
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