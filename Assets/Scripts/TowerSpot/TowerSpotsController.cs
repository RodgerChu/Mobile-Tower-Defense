using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpotsController : MonoBehaviour
{
    public TowerSpot[] spots;
    private TowerSpot selectedSpot;

    private void Awake()
    {
        foreach(var spot in spots)
        {
            spot.OnSpotSelected += OnSpotSelected;
        }
    }

    private void OnSpotSelected(TowerSpot spot)
    {
        selectedSpot = spot;
    }

    public void OnTowerBuild(TowerBuildCell cell)
    {
        selectedSpot.OnTowerBuild(cell);
    }
}
