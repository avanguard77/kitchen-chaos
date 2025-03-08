using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countainerCounterAnimation : MonoBehaviour
{
    private const string OpenClose = "OpenClose";
    [SerializeField] private CountainerCounter countainerCounter;
    
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        countainerCounter.OnPlayerGrabedObject+= CountainerCounterOnOnPlayerGrabedObject;
    }

    private void CountainerCounterOnOnPlayerGrabedObject(object sender, System.EventArgs e)
    {
        animator.SetTrigger(OpenClose);
    }
}