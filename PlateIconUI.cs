using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlateIconUI : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [FormerlySerializedAs("iconObject")] [SerializeField] private Transform iconTemplate;

    private void Awake()
    {
        iconTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        plateKitchenObject.OnIngridiantAdded += PlateKitchenObjectOnOnIngridiantAdded;
    }

    private void PlateKitchenObjectOnOnIngridiantAdded(object sender, PlateKitchenObject.OnIngridiantAddedEventArges e)
    {
        UpdateVisual();
    }
    private void UpdateVisual()
    {
        foreach (Transform child in transform)
        {
            if (child == iconTemplate)
            {
                continue;
            }
            Destroy(child.gameObject);
        }
        foreach (KitchenObjectSo kitchenObjectSo in plateKitchenObject.GetKitchenObjectSoList())
        {
            Transform iconTransform = Instantiate(iconTemplate, transform);
            iconTemplate.gameObject.SetActive(true);
            iconTransform.GetComponent<PlateSingleUI>().SetKitchenObjectSo(kitchenObjectSo);
        }
    }
}