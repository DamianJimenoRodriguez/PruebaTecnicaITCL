using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class PlayerInput : MonoBehaviour
{
    private NavMeshAgent agent;
    public LayerMask mask;
    public LayerMask UIMask;
    public float rayDistance = 100f;
    public float minHeiht;
    private bool canClick = true;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !IsPointerOverUIObject())
        {
            if (canClick)
            {
                MovePlayer();
            }
        }
    }

    public void MovePlayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistance, mask))
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.layer == UIMask)
            {
                return;
            }
            agent.destination = hit.point;
        }
    }
}