using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManagerUI : MonoBehaviour
{
    [SerializeField]private Transform container;
    [SerializeField]private Transform recepiTemplate;

    private void Awake()
    {
        recepiTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        DeliveryManager.Instance.OnRecepiSpawned+= InstanceOnOnRecepiSpawned;
        DeliveryManager.Instance.OnRecepiCompleted+= InstanceOnOnRecepiCompleted;
        UpdateVisual();
    }

    private void InstanceOnOnRecepiCompleted(object sender, EventArgs e)
    {
        UpdateVisual();
    }

    private void InstanceOnOnRecepiSpawned(object sender, EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (Transform child in container)
        {
            if (child==recepiTemplate)
            {
                continue;
            }
            Destroy(child.gameObject);
        }

        foreach (RecepiSo recepiSo in DeliveryManager.Instance.GetRecepiSoList())
        {
            Transform recepiTransform = Instantiate(recepiTemplate, container);
            recepiTransform.gameObject.SetActive(true);
            recepiTransform.GetComponent<DeliverySingleUI>().SetRecpiSo(recepiSo);
        }
    }
}
