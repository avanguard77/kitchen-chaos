using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlateIconUI : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private Transform iconTemplate;

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
    // Clear existing icons, excluding the template
    foreach (Transform child in transform)
    {
        if (child == iconTemplate)
        {
            continue;
        }
        Destroy(child.gameObject);
    }

    // Instantiate and set up icons for each KitchenObjectSo
    foreach (KitchenObjectSo kitchenObjectSo in plateKitchenObject.GetKitchenObjectSoList())
    {
        Transform iconTransform = Instantiate(iconTemplate, transform); // Create a new instance
        iconTransform.gameObject.SetActive(true); // Activate the new instance
        iconTransform.GetComponent<PlateSingleUI>().SetKitchenObjectSo(kitchenObjectSo); // Set the data
        Debug.Log(kitchenObjectSo); // Log the data
    }
}

}