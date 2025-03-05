using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
   
    

    public override void interact(Player player)
    {
        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSo.prefab, target);
            kitchenObjectTransform.GetComponent<KitchenObject>().setKitchenObjectParent(this);
        }
        else
        {
            kitchenObject.setKitchenObjectParent(player);
            Debug.Log(kitchenObject);
        }
    }

   
}