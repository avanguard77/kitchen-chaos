using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private string Player_Input_Binding = "Player_Input_Binding";
    public event EventHandler OnInteraction;
    public event EventHandler OnInteractionAlternative;
    public event EventHandler OnPauseAction;

    private PlayerInputSystem playerInputSystem;

    public static GameInput Instance { get; private set; }

    public enum Bindings
    {
        Move_Up,
        Move_Down,
        Move_Left,
        Move_Right,
        Interact,
        InteractAlternative,
        Pause,
    }

    private void Awake()
    {
        Instance = this;
        playerInputSystem = new PlayerInputSystem();
        if (PlayerPrefs.HasKey(Player_Input_Binding))
        {
            playerInputSystem.LoadBindingOverridesFromJson(PlayerPrefs.GetString(Player_Input_Binding));
        }

        playerInputSystem.Player.Enable();

        playerInputSystem.Player.interact.performed += interact_performed;
        playerInputSystem.Player.interactAlternatinive.performed += interact_alternative;
        playerInputSystem.Player.Pause.performed += PauseOnperformed;

        Debug.Log(GetBingingText(Bindings.Interact));
    }

    private void OnDestroy()
    {
        playerInputSystem.Player.interact.performed -= interact_performed;
        playerInputSystem.Player.interactAlternatinive.performed -= interact_alternative;
        playerInputSystem.Player.Pause.performed -= PauseOnperformed;

        playerInputSystem.Dispose();
    }

    private void PauseOnperformed(InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        if (OnInteraction != null)
        {
            OnInteraction(this, EventArgs.Empty);
        }
    }

    private void interact_alternative(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        OnInteractionAlternative?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 Getmovement()
    {
        Vector2 inputvector = playerInputSystem.Player.Move.ReadValue<Vector2>();

        inputvector = inputvector.normalized;

        return inputvector;
    }

    public string GetBingingText(Bindings bindings)
    {
        switch (bindings)
        {
            default:
            case Bindings.Interact:
                return playerInputSystem.Player.interact.bindings[0].ToDisplayString();
                break;
            case Bindings.InteractAlternative:
                return playerInputSystem.Player.interactAlternatinive.bindings[0].ToDisplayString();
                break;
            case Bindings.Pause:
                return playerInputSystem.Player.Pause.bindings[0].ToDisplayString();
                break;
            case Bindings.Move_Up:
                return playerInputSystem.Player.Move.bindings[1].ToDisplayString();
                break;
            case Bindings.Move_Down:
                return playerInputSystem.Player.Move.bindings[2].ToDisplayString();
                break;
            case Bindings.Move_Left:
                return playerInputSystem.Player.Move.bindings[3].ToDisplayString();
                break;
            case Bindings.Move_Right:
                return playerInputSystem.Player.Move.bindings[4].ToDisplayString();
                break;
        }
    }

    public void Rebinding(Bindings bindings, Action onAction)
    {
        playerInputSystem.Player.Disable();


        InputAction inputAction;
        int bindingIndex = 0;
        switch (bindings)
        {
            default:
            case Bindings.Interact:
                bindingIndex = 0;
                inputAction = playerInputSystem.Player.interact;
                break;
            case Bindings.InteractAlternative:
                bindingIndex = 0;
                inputAction = playerInputSystem.Player.interactAlternatinive;
                break;
            case Bindings.Pause:
                bindingIndex = 0;
                inputAction = playerInputSystem.Player.Pause;
                break;
            case Bindings.Move_Up:
                bindingIndex = 1;
                inputAction = playerInputSystem.Player.Move;
                break;
            case Bindings.Move_Down:
                bindingIndex = 2;
                inputAction = playerInputSystem.Player.Move;
                break;
            case Bindings.Move_Left:
                bindingIndex = 3;
                inputAction = playerInputSystem.Player.Move;
                break;
            case Bindings.Move_Right:
                bindingIndex = 4;
                inputAction = playerInputSystem.Player.Move;
                break;
        }

        inputAction.PerformInteractiveRebinding(bindingIndex).OnComplete(callback =>
        {
            callback.Dispose();
            playerInputSystem.Player.Enable();
            onAction();

            PlayerPrefs.SetString(Player_Input_Binding, playerInputSystem.SaveBindingOverridesAsJson());
            PlayerPrefs.Save();
        }).Start();
    }
}