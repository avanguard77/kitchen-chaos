using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteraction;
    private PlayerInputSystem playerInputSystem;

    private void Awake()
    {
        playerInputSystem = new PlayerInputSystem();
        playerInputSystem.Player.Enable();

        playerInputSystem.Player.interact.performed += interact_performed;
    }

    private void interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        if (OnInteraction != null)
        {
            OnInteraction(this, EventArgs.Empty);
        }
    }

    public Vector2 getmovement()
    {
        Vector2 inputvector = playerInputSystem.Player.Move.ReadValue<Vector2>();

        inputvector = inputvector.normalized;

        return inputvector;
    }
}