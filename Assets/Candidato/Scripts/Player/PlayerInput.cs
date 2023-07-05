using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInput : MonoBehaviour
{
    public System.Action<Vector3> OnPlayerInteraction;
}