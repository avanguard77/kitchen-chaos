using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSo kitchenObjectSo;
    

    private ClearCounter clearCounter;
    
    public KitchenObjectSo getKitchenObject()
    {
        return kitchenObjectSo;
    }

    public void setClearCounter(ClearCounter clearCounter)
    {
        if (this.clearCounter != null)
        {
            this.clearCounter.ClearKitchenObject();
        }
        this.clearCounter = clearCounter;
        clearCounter.setKitchenObject(this);

        transform.parent = this.clearCounter.getFollowTransform();
        transform.localPosition = Vector3.zero;
    }
    public ClearCounter GetClearCounter()
    {
        return clearCounter;
    }
}