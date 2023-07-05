using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinStorage : PlayerInteractable
{
    public override void OnPlayerInteract(Player player)
    {
        player.level.StoreCoins();
    }
}