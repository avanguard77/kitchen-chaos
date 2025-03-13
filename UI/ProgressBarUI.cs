using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] GameObject progressBarhasProgress;
    [SerializeField] private Image bar;
    private IHasProgress hasProgress;
    private void Start()
    {
        hasProgress = progressBarhasProgress.GetComponent<IHasProgress>();
        if (hasProgress==null)
        {
            Debug.LogError("ProgressBarUI has not been assigned");
        }
        hasProgress.OnProgressChanged += HasProgressOnOnProgressChanged;
        bar.fillAmount = 0f;
        Hide();
    }

    private void HasProgressOnOnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArg e)
    {
        Show();
        bar.fillAmount = e.progressNormalized;
        if (e.progressNormalized==0f||e.progressNormalized==1f)
        {
            Hide();
        }
        else
        {
            Show();
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