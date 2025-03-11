using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private List<KitchenObject_GameObject> kitchenObjectGameObjects;

    [Serializable]
    public struct KitchenObject_GameObject
    {
        public GameObject ObjGameObject;
        public KitchenObjectSo KitchenObjectSo;
    }

    private void Start()
    {
        plateKitchenObject.OnIngridiantAdded += PlateKitchenObjectOnOnIngridiantAdded;

        foreach (KitchenObject_GameObject kitchenObject_GameObject in kitchenObjectGameObjects)
        {
            kitchenObject_GameObject.ObjGameObject.SetActive(false);
        }
    }

    private void PlateKitchenObjectOnOnIngridiantAdded(object sender, PlateKitchenObject.OnIngridiantAddedEventArges e)
    {
        foreach (KitchenObject_GameObject kitchenObject_GameObject in kitchenObjectGameObjects)
        {
            if (kitchenObject_GameObject.KitchenObjectSo == e.KitchenObjectSo)
            {
                kitchenObject_GameObject.ObjGameObject.SetActive(true);
            }
        }
    }
}