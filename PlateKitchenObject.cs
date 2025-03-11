using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField]private List<KitchenObjectSo> validKitchenObjectSos;
    
    private List<KitchenObjectSo> kitchenObjects;

    private void Awake()
    {
        kitchenObjects = new List<KitchenObjectSo>();
    }

    public bool TryAddGradiant(KitchenObjectSo kitchenObjectSo)
    {
        if (!validKitchenObjectSos.Contains(kitchenObjectSo))
        {
            return false;
        }
        if (kitchenObjects.Contains(kitchenObjectSo))
        {
            return false;
        }
        else
        {
            kitchenObjects.Add(kitchenObjectSo);
            return true;
        }
    }
}