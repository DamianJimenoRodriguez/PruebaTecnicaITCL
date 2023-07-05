using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;

    private PlayerInput playerInput;

    [SerializeField] private Transform destinationCrossHair;

    [SerializeField] private Vector3 destinationCrossHairOffset;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        playerInput = GetComponent<PlayerInput>();
        playerInput.OnPlayerInteraction += MovePlayer;
    }

    public void MovePlayer(Vector3 newPos)
    {
        destinationCrossHair.gameObject.SetActive(true);
        agent.destination = newPos;
        destinationCrossHair.position = newPos + destinationCrossHairOffset;
    }
}