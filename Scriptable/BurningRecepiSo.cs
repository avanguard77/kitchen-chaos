using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BurningRecepiSo : ScriptableObject
{
    public KitchenObjectSo input;
    public KitchenObjectSo output;
    public int burningTimerMax;
}
