using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSo kitchenObject;

    public override void interact(Player player)
    {
        if (!hasKitchenObject())
        {
            //there is no kitchen Object here
            if (player.hasKitchenObject())
            {
                //player is carring sth
                player.getKitchenObject().setKitchenObjectParent(this);
            }
            else
            {
                //player is not carring sth
            }
        }
        else
        {
            //there is kitchen object 
            if (player.hasKitchenObject())
            {
                //player is carring 
                if (player.getKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    //there is a Plate that it is holding
                    if (plateKitchenObject.TryAddGradiant(getKitchenObject().GetKitchenObjectSo()))
                    {
                        getKitchenObject().destroySelf();
                    }
                }
                else
                {
                    //player is not holding plate but sth else 
                    if (getKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        if (plateKitchenObject.TryAddGradiant(player.getKitchenObject().GetKitchenObjectSo()))
                        {
                            player.getKitchenObject().destroySelf();
                        }
                    }
                }
            }
            else
            {
                //player is not 
                getKitchenObject().setKitchenObjectParent(player);
            }
        }
    }
}