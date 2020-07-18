using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TowerSpotsController : MonoBehaviour
{
    public UnitySpotSelectedEvent OnSpotTapped;

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
        OnSpotTapped?.Invoke(selectedSpot);
    }

    public void OnTowerBuild(TowerBuildCell cell)
    {
        selectedSpot.OnTowerBuild(cell);
    }

    public void OnTowerManagementCellAction(TowerManagementCellController cell)
    {
        selectedSpot.OnTowerManagementAction(cell);
    }
}
