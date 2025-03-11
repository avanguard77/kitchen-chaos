using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCounterVisual : MonoBehaviour
{
    [SerializeField]private PlateCounter plateCounter;
    [SerializeField] private Transform TopPoint;
    [SerializeField] private Transform plateVisualPrefab;

    private List<GameObject> plateVisuals;
    
    private void Awake()
    {
        plateVisuals = new List<GameObject>();
    }

    private void Start()
    {
        plateCounter.spawnPlate+= PlateCounterOnspawnPlate;
        plateCounter.RemovedPlate+= PlateCounterOnRemovedPlate;
    }

    private void PlateCounterOnRemovedPlate(object sender, EventArgs e)
    {
        GameObject plateVisual= plateVisuals[plateVisuals.Count - 1];
        plateVisuals.Remove(plateVisual);
        Destroy(plateVisual);
    }

    private void PlateCounterOnspawnPlate(object sender, EventArgs e)
    {
        Transform plateVisualTransform = Instantiate(plateVisualPrefab, TopPoint);
        
        float offset = .1f;
        plateVisualTransform.localPosition = new Vector3(0,offset*plateVisuals.Count , 0);
        plateVisuals.Add(plateVisualTransform.gameObject);
    }
}
