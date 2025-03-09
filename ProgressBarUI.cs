using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private CuttinCounter cuttinCounter;
    [SerializeField] private Image bar;

    private void Start()
    {
        cuttinCounter.OnProgressChanged += CuttinCounterOnOnProgressChanged;
        bar.fillAmount = 0f;
        Hide();
    }

    private void CuttinCounterOnOnProgressChanged(object sender, CuttinCounter.OnProgressChangedEventArg e)
    {
        Show();
        bar.fillAmount = e.progressNormalized;
        if (bar.fillAmount >= 1f)
        {
            Hide();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}