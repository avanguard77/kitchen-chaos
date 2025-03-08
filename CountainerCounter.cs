using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabedObject;

    public override void interact(Player player)
    {
        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSo.prefab, target);
            kitchenObjectTransform.GetComponent<KitchenObject>().setKitchenObjectParent(player);
            OnPlayerGrabedObject?.Invoke(this, EventArgs.Empty);
        }
    }
    
}
