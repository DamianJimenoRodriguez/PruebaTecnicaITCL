using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Super class used for objects for the player to interact
/// </summary>
public abstract class PlayerInteractable : MonoBehaviour
{
    public abstract void OnPlayerInteract(Player player);

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            OnPlayerInteract(player);
        }
    }
}