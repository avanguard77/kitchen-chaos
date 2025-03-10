using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField]private StoveCounter stoveCounter;
    [SerializeField]private GameObject stoveOnGameObject;
    [SerializeField]private GameObject particleGameObject;

    private void Start()
    {
        stoveCounter.OnStateChanged+= StoveCounterOnOnStateChanged;
    }

    private void StoveCounterOnOnStateChanged(object sender, StoveCounter.OnStateChangedArges e)
    {
        bool show = (e.state==StoveCounter.State.Fried || e.state==StoveCounter.State.Frying);
        stoveOnGameObject.SetActive(show);
        particleGameObject.SetActive(show);
    }
}
