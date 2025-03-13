using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recepiDeliveredText;

    private void Start()
    {
        KitchenManager.instance.OnStateChanged += KitchenManager_OnOnStateChanged;
        Hide();
    }

    private void KitchenManager_OnOnStateChanged(object sender, EventArgs e)
    {
        if (KitchenManager.instance.IsGameOver())
        {
            Show();
            recepiDeliveredText.text = DeliveryManager.Instance.GetSuccesfulRecepiAmount().ToString();
        }
        else
        {
            Hide();
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}