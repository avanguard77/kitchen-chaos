using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameCountDownUI : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI countDownText;

    private void Start()
    {
        KitchenManager.instance.OnStateChanged+= KitchenManager_OnOnStateChanged;
        Hide();
    }

    private void KitchenManager_OnOnStateChanged(object sender, EventArgs e)
    {
        if (KitchenManager.instance.IsGameCountToStart())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Update()
    {
        countDownText.text = KitchenManager.instance.GetGameCountDownTime().ToString("#");
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
