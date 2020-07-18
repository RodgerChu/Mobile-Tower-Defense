using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManagementDisplayController : MonoBehaviour
{
    public TowerManagementCellController upgradeCell;
    public TowerManagementCellController sellCell;

    public void Hide()
    {
        gameObject.transform.localScale = Vector3.zero;
        upgradeCell.SetUnselected();
        sellCell.SetUnselected();
    }

    public void Show(TowerController selectedTower)
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        upgradeCell.LoadCell(selectedTower, TowerManagementAction.UPGRADE);
        sellCell.LoadCell(selectedTower, TowerManagementAction.SELL);
    }
}
