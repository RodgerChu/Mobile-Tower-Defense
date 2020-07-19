using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildController : MonoBehaviour
{
    public PlayerResourceController playerResources;

    public void OnTowerBuildCellSelected(TowerBuildCell cell)
    {
        var towerCost = cell.tower.towerStatsPrefab.cost;
        if (towerCost <= playerResources.GetCurrentMoney())
        {
            cell.SetSelected();
        }
    }

    public void OnTowerBuild(TowerBuildCell cell)
    {
        var towerCost = cell.tower.towerStatsPrefab.cost;
        playerResources.DecreaseMoney((uint)towerCost);
    }

    public void OnTowerManagementCellSelected(TowerManagementCellController cell)
    {
        var action = cell.action;

        switch (action)
        {
            case TowerManagementAction.UPGRADE:
                var cost = cell.ActionCost;
                if (cost <= playerResources.GetCurrentMoney())
                {
                    cell.SetSelected();
                }
                break;
            default:
                cell.SetSelected();
                break;
        }
    }

    public void OnTowerManagementAction(TowerManagementCellController cell)
    {
        var action = cell.action;
        var actionCost = cell.ActionCost;

        switch (action)
        {
            case TowerManagementAction.UPGRADE:
                playerResources.DecreaseMoney(actionCost);
                break;
            default:
                playerResources.IncreaseMoney(actionCost);
                break;
              
        }
    }
}
