using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteraction;
    public event EventHandler OnInteractionAlternative;
    public event EventHandler OnPauseAction;
    
    private PlayerInputSystem playerInputSystem;

    public static GameInput Instance{get; private set;}
    
    private void Awake()
    {
        Instance = this;
        playerInputSystem = new PlayerInputSystem();
        playerInputSystem.Player.Enable();

        playerInputSystem.Player.interact.performed += interact_performed;
        playerInputSystem.Player.interactAlternatinive.performed+=interact_alternative;
        playerInputSystem.Player.Pause.performed+= PauseOnperformed;
    }

    private void OnDestroy()
    {
        playerInputSystem.Player.interact.performed -= interact_performed;
        playerInputSystem.Player.interactAlternatinive.performed-=interact_alternative;
        playerInputSystem.Player.Pause.performed-= PauseOnperformed;
        
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
}