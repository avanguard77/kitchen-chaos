using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliverySingleUI : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI recepiNameText;
    [SerializeField]private Transform iconContainer;
    [SerializeField]private Transform iconTemplate;


    private void Awake()
    {
        iconTemplate.gameObject.SetActive(false);
    }
    public void SetRecpiSo(RecepiSo receipSo)
    {
        recepiNameText.text = receipSo.name;
        foreach (Transform child in iconContainer)
        {
            if (child == iconTemplate)
            {
                continue;
            }
            Debug.Log("Destroying child: " + child.name);
            Destroy(child.gameObject);
        }

        foreach (KitchenObjectSo kitchenObjectSo in receipSo.KitchenObjectSoLiast)
        {
            if (kitchenObjectSo.sprite == null)
            {
                Debug.LogWarning("KitchenObject " + kitchenObjectSo.name + " has no sprite assigned!");
                continue;
            }

            Transform iconTransform = Instantiate(iconTemplate, iconContainer);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<Image>().sprite = kitchenObjectSo.sprite;
            
        }
    }

}
