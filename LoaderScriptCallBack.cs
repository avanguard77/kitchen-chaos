using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderScriptCallBack : MonoBehaviour
{
    private bool isFirstLoad = true;

    private void Update()
    {
        if (isFirstLoad)
        {
            isFirstLoad = false;
            
            Loader.LoaderCallBack();
        }
    }
}
