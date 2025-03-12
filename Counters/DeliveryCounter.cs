using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void interact(Player player)
    {
        if (player.hasKitchenObject())
        {
            if (player.getKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
            {
                DeliveryManager.Instance.DeliveryRecepiSo(plateKitchenObject);
                player.getKitchenObject().destroySelf();
            }
        }
    }
}
