using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
   
    [SerializeField]private KitchenObjectSo kitchenObject;

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
            }
            else
            {
                //player is not 
                getKitchenObject().setKitchenObjectParent(player);
            }
        }
    }

   
}