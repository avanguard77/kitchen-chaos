using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DeliveryManager : MonoBehaviour
{
    public event EventHandler OnRecepiSpawned;
    public event EventHandler OnRecepiCompleted;

    public static DeliveryManager Instance { get; private set; }

    [SerializeField] private RecepiListSo recepiListSo;

    private List<RecepiSo> waitingRecepiSoList;
    private float spawnRecepiSoTimer;
    private const float spawnRecepiSoTimerMax = 4f;
    private int waitingRecepiSoCountMax = 4;
    public int succesfulRecepiAmount = 0;

    private void Awake()
    {
        Instance = this;
        waitingRecepiSoList = new List<RecepiSo>();
        spawnRecepiSoTimer = spawnRecepiSoTimerMax;
    }

    private void Update()
    {
        spawnRecepiSoTimer -= Time.deltaTime;
        if (spawnRecepiSoTimer <= 0)
        {
            spawnRecepiSoTimer = spawnRecepiSoTimerMax;
            if (waitingRecepiSoList.Count < waitingRecepiSoCountMax)
            {
                RecepiSo waitingRecepiSo = recepiListSo.RecepiSoList[Random.Range(0, recepiListSo.RecepiSoList.Count)];
                waitingRecepiSoList.Add(waitingRecepiSo);
                OnRecepiSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }


    public void DeliveryRecepiSo(PlateKitchenObject plateKitchenObject)
    {
        for (int i = 0; i < waitingRecepiSoList.Count; i++)
        {
            RecepiSo waitingRecepiSo = waitingRecepiSoList[i];
            if (waitingRecepiSo.KitchenObjectSoLiast.Count == plateKitchenObject.GetKitchenObjectSoList().Count)
            {
                bool plateContentsMatch = true;
                foreach (KitchenObjectSo recepKitchenObjectSo in waitingRecepiSo.KitchenObjectSoLiast)
                {
                    bool ingeridiantfound = false;
                    foreach (KitchenObjectSo plateKitchenObjectSo in plateKitchenObject.GetKitchenObjectSoList())
                    {
                        if (plateKitchenObjectSo == recepKitchenObjectSo)
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

                if (plateContentsMatch)
                {
                    //delivered
                    waitingRecepiSoList.RemoveAt(i);
                    succesfulRecepiAmount++;
                    OnRecepiCompleted?.Invoke(this, EventArgs.Empty);

                    return;
                }
            }
        }
    }

    public List<RecepiSo> GetRecepiSoList()
    {
        return waitingRecepiSoList;
    }

    public int GetSuccesfulRecepiAmount()
    {
        return succesfulRecepiAmount;
    }
}