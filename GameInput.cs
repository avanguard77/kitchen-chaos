using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteraction;
    public event EventHandler OnInteractionAlternative;
    private PlayerInputSystem playerInputSystem;

    private void Awake()
    {
        playerInputSystem = new PlayerInputSystem();
        playerInputSystem.Player.Enable();

        playerInputSystem.Player.interact.performed += interact_performed;
        playerInputSystem.Player.interactAlternatinive.performed+=interact_alternative;
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
}