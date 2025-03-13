using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttinCounter : BaseCounter,IHasProgress
{
    public event EventHandler<IHasProgress.OnProgressChangedEventArg> OnProgressChanged;
    

    public static event EventHandler OnCut;

    public static void ResetOnCut()
    {
        OnCut = null;
    }

    [SerializeField] private CuttingRecepiSo[] cuttingObjectSo;
    private int cuttingProgress;

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
                    cuttingProgress = 0;
                    CuttingRecepiSo cuttingRecepiSo =
                        GetCuttingRecepiSowithInput(getKitchenObject().GetKitchenObjectSo());
                    OnProgressChanged?.Invoke(this,
                        new IHasProgress.OnProgressChangedEventArg
                            { progressNormalized = (float)cuttingProgress / cuttingRecepiSo.cuttingProgressMax });
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
                if (player.getKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    //there is a Plate that it is holding
                    if (plateKitchenObject.TryAddGradiant(getKitchenObject().GetKitchenObjectSo()))
                    {
                        getKitchenObject().destroySelf();
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

    public override void interactAlternative(Player player)
    {
        if (hasKitchenObject() && HasKitchenRecepi(getKitchenObject().GetKitchenObjectSo()))
        {
            //there is kitchen Object
            CuttingRecepiSo cuttingRecepiSo = GetCuttingRecepiSowithInput(getKitchenObject().GetKitchenObjectSo());
            cuttingProgress++;
            
            OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArg
                { progressNormalized = (float)cuttingProgress / cuttingRecepiSo.cuttingProgressMax });
            
            OnCut?.Invoke(this, EventArgs.Empty);

            if (cuttingProgress >= cuttingRecepiSo.cuttingProgressMax)
            {
                KitchenObjectSo kitchenObjectSo = getInputSetOutput(getKitchenObject().GetKitchenObjectSo());

                getKitchenObject().destroySelf();
                KitchenObject.SpawnKitchenObject(kitchenObjectSo, this);
            }
        }
    }

    private bool HasKitchenRecepi(KitchenObjectSo kitchenObjectSo)
    {
        CuttingRecepiSo cuttingRecepiSo = GetCuttingRecepiSowithInput(kitchenObjectSo);
        return cuttingRecepiSo != null;
    }

    private KitchenObjectSo getInputSetOutput(KitchenObjectSo kitchenObjectSo)
    {
        CuttingRecepiSo cuttingRecepiSo = GetCuttingRecepiSowithInput(kitchenObjectSo);
        if (cuttingObjectSo != null)
        {
            return cuttingRecepiSo.output;
        }

        return null;
    }

    private CuttingRecepiSo GetCuttingRecepiSowithInput(KitchenObjectSo inputKitchenObjectSo)
    {
        foreach (CuttingRecepiSo cuttingRecepiSo in cuttingObjectSo)
        {
            if (cuttingRecepiSo.input == inputKitchenObjectSo)
            {
                return cuttingRecepiSo;
            }
        }

        return null;
    }
}