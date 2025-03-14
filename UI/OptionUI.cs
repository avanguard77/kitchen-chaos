using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    public static OptionUI instance { get; private set; }

    [SerializeField] private Button soundEffectButton;
    [SerializeField] private Button MuseicEffectButton;
    [SerializeField] private Button CloseButton;
    [SerializeField] private TextMeshProUGUI soundEffectText;
    [SerializeField] private TextMeshProUGUI MusicEffectText;
    [SerializeField] private TextMeshProUGUI MoveUpText;
    [SerializeField] private TextMeshProUGUI MoveDownText;
    [SerializeField] private TextMeshProUGUI MoverRightText;
    [SerializeField] private TextMeshProUGUI MoveLeftText;
    [SerializeField] private TextMeshProUGUI InteractText;
    [SerializeField] private TextMeshProUGUI InteractAlternatvieText;
    [SerializeField] private TextMeshProUGUI Paused;
    [SerializeField] private Button MoveUpButton;
    [SerializeField] private Button MoveDownButton;
    [SerializeField] private Button MoverRightButton;
    [SerializeField] private Button MoveLeftButton;
    [SerializeField] private Button InteractButton;
    [SerializeField] private Button InteractAlternatvieButton;
    [SerializeField] private Button PauseButton;
    [SerializeField] private Transform pressRebindKey;

    private void Awake()
    {
        instance = this;
        soundEffectButton.onClick.AddListener((() => { UpdateVisual(); }));
        MuseicEffectButton.onClick.AddListener((() =>
        {
            UpdateVisual();
            MusicManager.Instance.ChangeVolume();
        }));
        CloseButton.onClick.AddListener((() => { Hide(); }));
        MoveUpButton.onClick.AddListener((() => { ResetPressRebindKey(GameInput.Bindings.Move_Up); }));
        MoveDownButton.onClick.AddListener((() => { ResetPressRebindKey(GameInput.Bindings.Move_Down); }));
        MoverRightButton.onClick.AddListener((() => { ResetPressRebindKey(GameInput.Bindings.Move_Right); }));
        MoveLeftButton.onClick.AddListener((() => { ResetPressRebindKey(GameInput.Bindings.Move_Left); }));
        InteractButton.onClick.AddListener((() => { ResetPressRebindKey(GameInput.Bindings.Interact); }));
        InteractAlternatvieButton.onClick.AddListener((() =>
        {
            ResetPressRebindKey(GameInput.Bindings.InteractAlternative);
        }));
        PauseButton.onClick.AddListener((() => { ResetPressRebindKey(GameInput.Bindings.Pause); }));
    }

    private void Start()
    {
        UpdateVisual();
        HidePressRebindKey();
        Hide();
    }

    private void UpdateVisual()
    {
        MusicEffectText.text = "Music Effect :" + Math.Round(MusicManager.Instance.GetVolume() * 10f);

        MoveUpText.text = GameInput.Instance.GetBingingText(GameInput.Bindings.Move_Up);
        MoveDownText.text = GameInput.Instance.GetBingingText(GameInput.Bindings.Move_Down);
        MoveLeftText.text = GameInput.Instance.GetBingingText(GameInput.Bindings.Move_Left);
        MoverRightText.text = GameInput.Instance.GetBingingText(GameInput.Bindings.Move_Right);
        InteractText.text = GameInput.Instance.GetBingingText(GameInput.Bindings.Interact);
        InteractAlternatvieText.text = GameInput.Instance.GetBingingText(GameInput.Bindings.InteractAlternative);
        Paused.text = GameInput.Instance.GetBingingText(GameInput.Bindings.Pause);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ShowPressRebindKey()
    {
        pressRebindKey.gameObject.SetActive(true);
    }

    public void HidePressRebindKey()
    {
        pressRebindKey.gameObject.SetActive(false);
    }

    private void ResetPressRebindKey(GameInput.Bindings binding)
    {
        ShowPressRebindKey();
        GameInput.Instance.Rebinding(binding, () =>
        {
            HidePressRebindKey();
            UpdateVisual();
        });
    }
}