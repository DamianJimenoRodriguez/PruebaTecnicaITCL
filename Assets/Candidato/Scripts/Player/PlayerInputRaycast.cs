using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Child class of PlayerInput.
/// Uses Raycast to calculate the player next position
/// The method used to calculate the ray is Camera.ScreenPointToRay
/// Since we are using GetButton("Fire") for the input and
/// mouse.positon for the ray, this script works on both
/// Pc and mobile devices
/// </summary>
public class PlayerInputRaycast : PlayerInput
{
    [SerializeField] private LayerMask mask;
    [SerializeField] private float rayDistance = 100f;
    [SerializeField] private Camera cam;

    private void Awake()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && !IsPointerOverUIObject())
        {
            CheckValidInteraction();
        }
    }

    public void CheckValidInteraction()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, mask))
        {
            if (hit.collider != null && OnPlayerInteraction != null)
            {
                OnPlayerInteraction(hit.point, hit.normal);
            }
        }
    }
}