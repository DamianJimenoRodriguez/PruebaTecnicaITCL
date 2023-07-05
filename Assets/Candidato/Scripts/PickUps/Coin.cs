using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PickUp
{
    [SerializeField] private int cointValue;

    public override void OnPickUp(Player player)
    {
        player.level.AddScore(cointValue);
    }
}