using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField]private Transform target;
    [SerializeField]private KitchenObjectSo kitchenObjectSo;
    public void interact()
    {
        Transform kitchenObjectTransform =Instantiate(kitchenObjectSo.prefab, target);
        kitchenObjectTransform.localPosition = Vector3.zero;
    }
}