using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabedObject;

    public override void interact(Player player)
    {
        if (!player.hasKitchenObject())
        {
            KitchenObject.SpawnKitchenObject(kitchenObjectSo, player);
            OnPlayerGrabedObject?.Invoke(this, EventArgs.Empty);
        }
    }
    
}
