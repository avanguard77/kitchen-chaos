using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSo kitchenObjectSo;

    public KitchenObjectSo getKitchenObject()
    {
        return kitchenObjectSo;
    }
}