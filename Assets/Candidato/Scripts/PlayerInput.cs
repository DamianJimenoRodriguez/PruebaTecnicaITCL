using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerInput : MonoBehaviour
{
    private NavMeshAgent agent;
    public LayerMask mask;
    public float rayDistance = 100f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            MovePlayer();
        }
    }

    public void MovePlayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistance, mask))
        {
            agent.destination = hit.point;
        }
    }
}