using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PickUp
{
    public override void OnPickUp(Player player)
    {
        player.level.GetCoin();
    }
}