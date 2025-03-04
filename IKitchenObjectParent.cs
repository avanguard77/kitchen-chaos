using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent
{
    public Transform getFollowTransform();
    public void setKitchenObject(KitchenObject kitchenObject);

    public KitchenObject getKitchenObject();

    public void ClearKitchenObject();

    public bool hasKitchenObject();
}
