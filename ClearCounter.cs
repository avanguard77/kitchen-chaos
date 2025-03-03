using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private KitchenObjectSo kitchenObjectSo;
    [SerializeField]private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;

    private KitchenObject kitchenObject;

    private void Update()
    {
        if (testing&&Input.GetKey(KeyCode.T))
        {
            if (kitchenObject != null)
            {
                kitchenObject.setClearCounter(secondClearCounter);
            }
        }
    }

    public void interact()
    {
        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSo.prefab, target);
            kitchenObjectTransform.localPosition = Vector3.zero;
            
            kitchenObject=kitchenObjectTransform.GetComponent<KitchenObject>();
            kitchenObject.setClearCounter(this);
        }
        else
        {
            Debug.Log(kitchenObject);
        }
    }

    public Transform getFollowTransform()
    {
        return target;
    }

    public void setKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject getKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool hasKitchenObject()
    {
        return kitchenObject != null;
    }
}