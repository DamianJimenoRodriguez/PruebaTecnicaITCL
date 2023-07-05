using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

/// <summary>
/// Script that moves the player object in the scene.
/// It uses a NavMeshAgent to do so.
/// Receibes new positions from a script of type PlayerInput
/// which currently uses raycast
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;

    private PlayerInput playerInput;

    [SerializeField] private Transform destinationCrossHair;

    [SerializeField] private float destinationCrossHairOffset;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        playerInput = GetComponent<PlayerInput>();
        playerInput.OnPlayerInteraction += MovePlayer;
    }

    public void MovePlayer(Vector3 newPos, Vector3 normal)
    {
        destinationCrossHair.gameObject.SetActive(true);
        agent.destination = newPos;
        destinationCrossHair.rotation = Quaternion.LookRotation(normal);
        destinationCrossHair.position = newPos + normal * destinationCrossHairOffset;
    }
}