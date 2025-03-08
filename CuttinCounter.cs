using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttinCounter : BaseCounter
{
    [SerializeField]private CuttingRecepiSo[] cuttingObjectSo;
    public override void interact(Player player)
    {
        if (!hasKitchenObject())
        {
            //there is no kitchen Object here
            if (player.hasKitchenObject())
            {
                if (HasKitchenRecepi(player.getKitchenObject().GetKitchenObjectSo()))
                {
                    player.getKitchenObject().setKitchenObjectParent(this);    
                }
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
        if (hasKitchenObject()&&HasKitchenRecepi(getKitchenObject().GetKitchenObjectSo()))
        {
            //there is kitchen Object
            KitchenObjectSo kitchenObjectSo = getInputSetOutput(getKitchenObject().GetKitchenObjectSo());
            
            getKitchenObject().destroySelf();
            KitchenObject.SpawnKitchenObject(kitchenObjectSo,this);
        }
    }

    private bool HasKitchenRecepi(KitchenObjectSo kitchenObjectSo)
    {
        foreach (CuttingRecepiSo cuttingRecepiSo in cuttingObjectSo)
        {
            if (cuttingRecepiSo.input==kitchenObjectSo)
            {
                return true;
            }
        }
        return false;
    }

    private KitchenObjectSo getInputSetOutput(KitchenObjectSo kitchenObjectSo)
    {
        foreach (CuttingRecepiSo cuttingRecepiSo in cuttingObjectSo)
        {
            if (cuttingRecepiSo.input==kitchenObjectSo)
            {
                return cuttingRecepiSo.output;
            }
        }
        return null;
    }
}
