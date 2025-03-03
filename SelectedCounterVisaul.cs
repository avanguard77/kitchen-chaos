using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisaul : MonoBehaviour
{
    [SerializeField] ClearCounter counter;
    [SerializeField] GameObject visaulGameObject;
    private void Start()
    {
        Player.Instance.onSelectectedCounterChanged+= Player_Onselected; 
    }

    private void Player_Onselected(object sender, Player.OnSelectectedCounterChangedEventArgs e)
    {
        if (e.selectectedCounter == counter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Hide()
    {
        visaulGameObject.SetActive(false);
    }

    private void Show()
    {
        visaulGameObject.SetActive(true);
    }
}
