using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePausedUI : MonoBehaviour
{
    [SerializeField] private Button backMenuButton;

    [SerializeField] private Button resumeButton;

    private void Awake()
    {
        backMenuButton.onClick.AddListener(() =>
        {
            KitchenManager.instance.PuaseGame();
        });
        resumeButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameMenuScene);
        });
    }

    private void Start()
    {
        KitchenManager.instance.OnGamePaused += KitchenManeger_OnGamePaused;
        KitchenManager.instance.OnGameUnPaused += KitchenManager_OnGameUnPaused;
        Hide();
    }

    private void KitchenManager_OnGameUnPaused(object sender, EventArgs e)
    {
        Hide();
    }

    private void KitchenManeger_OnGamePaused(object sender, EventArgs e)
    {
        Show();
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