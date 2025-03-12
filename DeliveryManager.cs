using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance{get; private set;}
    
    [SerializeField] private RecepiListSo recepiListSo;

    private List<RecepiSo> waitingRecepiSoList;
    private float spawnRecepiSoTimer = 4f;
    private float spawnRecepiSoTimerMax;
    private int waitingRecepiSoCountMax = 4;

    private void Awake()
    {
        Instance = this;
        waitingRecepiSoList = new List<RecepiSo>();
    }

    private void Update()
    {
        spawnRecepiSoTimer -= Time.deltaTime;
        if (spawnRecepiSoTimer<=0)
        {
            spawnRecepiSoTimer = spawnRecepiSoTimerMax;
            if (waitingRecepiSoList.Count<=waitingRecepiSoCountMax)
            {
                RecepiSo waitingRecepiSo = recepiListSo.RecepiSoList[Random.Range(0, recepiListSo.RecepiSoList.Count)];
                Debug.Log(waitingRecepiSo.RecepiSoName);
                waitingRecepiSoList.Add(waitingRecepiSo);
            }
        }
    }

    public void DeliveryRecepiSo(PlateKitchenObject plateKitchenObject)
    {
        for (int i = 0; i < waitingRecepiSoList.Count; i++)
        {
            RecepiSo waitingRecepiSo = waitingRecepiSoList[i];
            if (waitingRecepiSo.KitchenObjectSoLiast.Count==plateKitchenObject.GetKitchenObjectSoList().Count)
            {
                bool plateContentsMatch = true;
                foreach (KitchenObjectSo recepKitchenObjectSo in waitingRecepiSo.KitchenObjectSoLiast)
                {
                    bool ingeridiantfound = false;
                    foreach (KitchenObjectSo plateKitchenObjectSo in plateKitchenObject.GetKitchenObjectSoList())
                    {
                        if (plateKitchenObjectSo==recepKitchenObjectSo)
                        {
                            //match
                            ingeridiantfound = true;
                            break;
                        }
                    }

                    if (!ingeridiantfound)
                    {
                        plateContentsMatch = false;
                    }
                }

                if (!plateContentsMatch)
                {
                    //delivered
                    Debug.Log("Delivered");
                    waitingRecepiSoList.RemoveAt(i);
                    return;
                }
            }
        }
    }
}