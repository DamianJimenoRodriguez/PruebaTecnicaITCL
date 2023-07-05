using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SuperClass that provides PlayerMovement with a new position for the player to move
/// </summary>
public abstract class PlayerInput : MonoBehaviour
{
    public System.Action<Vector3, Vector3> OnPlayerInteraction;
}