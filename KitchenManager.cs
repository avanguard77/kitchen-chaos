using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenManager : MonoBehaviour
{
    public static KitchenManager instance{get; set;}
    
    public event EventHandler OnStateChanged;
    
    private enum State
    {
        WaitingToStart,
        CountingdownToStart,
        GamePlaying,
        GameOver,
    }
    private State state;
    private float waitingToStartTimer=1f;
    private float countingdownToStartTimer=3f;
    private float gamePlayingTimer=10f;

    public void Awake()
    {
        instance = this;
        state = State.WaitingToStart;
    }

    private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if (waitingToStartTimer <= 0)
                {
                    state = State.CountingdownToStart;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.CountingdownToStart:
                countingdownToStartTimer -= Time.deltaTime;
                if (countingdownToStartTimer <= 0)
                {
                    state = State.GamePlaying;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer <= 0)
                {
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GameOver:
                OnStateChanged?.Invoke(this, EventArgs.Empty);
                break;
        }
        Debug.Log(state);
    }

    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }
    public bool IsGameCountToStart()
    {
        return state == State.CountingdownToStart;
    }
    public float GetGameCountDownTime()
    {
        return countingdownToStartTimer;
    }
}