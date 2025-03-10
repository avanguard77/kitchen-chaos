using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasProgress 
{
    public event EventHandler<OnProgressChangedEventArg> OnProgressChanged;

    public class OnProgressChangedEventArg : EventArgs
    {
        public float progressNormalized;
    }
}
