using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    
    public static OptionUI instance{get; private set;}
    
    [SerializeField]private Button soundEffectButton;
    [SerializeField]private Button MuseicEffectButton;
    [FormerlySerializedAs("CloseEffectButton")] [SerializeField]private Button CloseButton;
    [SerializeField]private TextMeshProUGUI soundEffectText;
    [SerializeField]private TextMeshProUGUI MusicEffectText;

    private void Awake()
    {
        instance = this;
        soundEffectButton.onClick.AddListener((() =>
        {
            UpdateVisual();
            
        }));
        MuseicEffectButton.onClick.AddListener((() =>
        {
            UpdateVisual();
            MusicManager.Instance.ChangeVolume();
        }));
        CloseButton.onClick.AddListener((() =>
        {
            Hide();
        }));
    }

    private void Start()
    {
        UpdateVisual();
        Hide();
    }

    private void UpdateVisual()
    {
        
        MusicEffectText.text="Music Effect :"+Math.Round(MusicManager.Instance.GetVolume()*10f);
        
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
