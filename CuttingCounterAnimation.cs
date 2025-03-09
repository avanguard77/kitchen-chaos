using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterAnimation : MonoBehaviour
{
    private const string OpenClose = "Cut";
    [SerializeField] private CuttinCounter cuttinCounter;
    
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        cuttinCounter.OnCut+= CuttinCounterOnOnCut ;
    }

    private void CuttinCounterOnOnCut(object sender, EventArgs e)
    {
        animator.SetTrigger(OpenClose);
    }
}