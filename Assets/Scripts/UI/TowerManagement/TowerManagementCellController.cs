using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerManagementCellController : MonoBehaviour
{
    public UnityTowerManagementCellTapEvent OnCellSelected;
    public UnityTowerManagementCellTapEvent OnCellAction;

    public Image ActionIcon;
    public TextMeshProUGUI ActionCostText;
    public Sprite OnSelectedSprite;
    public Sprite ActionSprite;

    public TowerController selectedTower;
    public TowerManagementAction action;
    public uint ActionCost = 0;
    

    private bool selected = false;

    private void Start()
    {
        ActionIcon.sprite = ActionSprite;
    }

    public void FireOnCellTap()
    {
        if (selected)
        {
            OnCellAction?.Invoke(this);
        }
        else
        {
            OnCellSelected?.Invoke(this);
        }
    }

    public void SetSelected()
    {
        selected = true;
        ActionIcon.sprite = OnSelectedSprite;
    }

    public void SetUnselected()
    {
        selected = false;
        ActionIcon.sprite = ActionSprite;
    }

    public void LoadCell(TowerController tower, TowerManagementAction action)
    {
        selectedTower = tower;
        this.action = action;

        switch (action)
        {
            case TowerManagementAction.UPGRADE:
                ActionCost = tower.towerStatsPrefab.upgradeCost;
                break;
            default:
                ActionCost = tower.towerStatsPrefab.cost;
                break;
        }

        ActionCostText.text = ActionCost.ToString();
    }
}
