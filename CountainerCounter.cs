using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountainerCounter : BaseCounter
{
    
    

    public override void interact(Player player)
    {
        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSo.prefab, target);
            kitchenObjectTransform.GetComponent<KitchenObject>().setKitchenObjectParent(player);
        }
    }
    
}
