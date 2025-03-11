using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    public event EventHandler<OnIngridiantAddedEventArges> OnIngridiantAdded;

    public class OnIngridiantAddedEventArges : EventArgs
    {
        public KitchenObjectSo KitchenObjectSo;
    }

    [SerializeField] private List<KitchenObjectSo> validKitchenObjectSos;

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
            OnIngridiantAdded?.Invoke(this, new OnIngridiantAddedEventArges { KitchenObjectSo = kitchenObjectSo });
            return true;
        }
    }

    public List<KitchenObjectSo> GetKitchenObjectSoList()
    {
        return kitchenObjects;
    }
}