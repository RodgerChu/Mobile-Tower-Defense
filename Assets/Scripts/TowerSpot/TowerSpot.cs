using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class TowerSpot : MonoBehaviour
{
    public UnityEvent OnEmptySpotTap;
    public UnityEvent OnTowerTap;

    public TowerController buildedTower;
    public Transform buildedTowerParent;

    public Action<TowerSpot> OnSpotSelected;

    public void OnTowerBuild(TowerBuildCell cell)
    {
        var towerController = Instantiate(cell.tower, buildedTowerParent);
        towerController.transform.localScale = new Vector3(1, 1, 1);
        if (towerController == null)
        {
            Debug.LogWarning("Created tower without Tower Controller component");
        }
        else
        {
            buildedTower = towerController;
        }       
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("Selected");
        OnSpotSelected(this);
        if (buildedTower == null)
        {
            OnEmptySpotTap?.Invoke();
        }
        else
        {
            OnTowerTap?.Invoke();
        }
    }
}
