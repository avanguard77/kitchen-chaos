using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCounter : BaseCounter
{
    public event EventHandler spawnPlate;
    public event EventHandler RemovedPlate;
    
    [SerializeField]private KitchenObjectSo plateKitchenObjectSo;
    
    private float spawnPlateCounter ;
    private float spawnPlateCounterMax = 4f;
    private int spantPlateAmount = 0;
    private int spantPlateAmountMax = 3;
    

    private void Update()
    {
        spawnPlateCounter += Time.deltaTime;
        if (spawnPlateCounter >= spawnPlateCounterMax)
        {
            spawnPlateCounter = 0f;
            if (spantPlateAmount < spantPlateAmountMax)
            {
                spawnPlate?.Invoke(this, EventArgs.Empty);
                spantPlateAmount += 1;
            }
        }
    }

    public override void interact(Player player)
    {
        if (!player.hasKitchenObject())
        {
            //player doesnt have kitchenObject
            if (spantPlateAmount>0)
            {
                spantPlateAmount--;
                KitchenObject.SpawnKitchenObject(plateKitchenObjectSo,player);
                
                RemovedPlate?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}