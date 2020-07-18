using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class TowerSpot : MonoBehaviour
{
    public TowerController buildedTower;
    public Transform buildedTowerParent;

    public Action<TowerSpot> OnSpotSelected;

    public void OnTowerBuild(TowerBuildCell cell)
    {
        var towerObject = PoolManager.GetFromPool(cell.tower);
        towerObject.transform.parent = buildedTowerParent;
        towerObject.transform.localScale = new Vector3(1, 1, 1);
        towerObject.transform.localPosition = Vector3.zero;

        var towerController = towerObject.GetComponent<TowerController>();
        if (towerController == null)
        {
            Debug.LogWarning("Created tower without Tower Controller component");
        }
        else
        {
            buildedTower = towerController;
        }       
    }

    public void OnTowerManagementAction(TowerManagementCellController cell)
    {
        var action = cell.action;

        switch (action)
        {
            case TowerManagementAction.UPGRADE:
                buildedTower.UpgradeTower();
                break;
            default:
                PoolManager.AddToPool(buildedTower);
                buildedTower = null;
                break;
        }
    }

    private void OnMouseUpAsButton()
    {
        if (EventSystem.current.currentSelectedGameObject?.name == null)
        {            
            OnSpotSelected(this);
        }
    }
}
