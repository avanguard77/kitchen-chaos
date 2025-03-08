using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttinCounter : BaseCounter
{
    [SerializeField]private KitchenObjectSo cuttingObjectSo;
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

    public override void interactAlternative(Player player)
    {
        if (hasKitchenObject())
        {
            //there is kitchen Object
            getKitchenObject().destroySelf();
            KitchenObject.SpawnKitchenObject(cuttingObjectSo,this);
        }
        else
        {
            
        }
    }
}
