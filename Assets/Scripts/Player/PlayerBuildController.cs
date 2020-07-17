using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildController : MonoBehaviour
{
    public PlayerResourceController playerResources;

    public void OnTowerBuildCellSelected(TowerBuildCell cell)
    {
        var towerCost = cell.tower.towerStats.cost;
        if (towerCost <= playerResources.GetCurrentMoney())
        {
            cell.SetSelected();
        }
    }

    public void OnTowerBuild(TowerBuildCell cell)
    {
        var towerCost = cell.tower.towerStats.cost;
        playerResources.DecreaseMoney((uint)towerCost);
    }
}
