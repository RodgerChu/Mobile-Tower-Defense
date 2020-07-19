using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerInfoDisplayController : MonoBehaviour
{
    public GameObject displayObject;
    public Image towerIcon;
    public TextMeshProUGUI towerName;
    public TextMeshProUGUI towerAttackDamage;
    public TextMeshProUGUI towerAttackSpeed;
    public TextMeshProUGUI towerAttackRange;

    private void Awake()
    {
        Hide();
    }

    public void OnTowerSpotSelected(TowerSpot towerSpot)
    {
        var tower = towerSpot.buildedTower;
        if (tower == null)
            return;

        ShowTowerInfo(tower);
    }

    public void OnTowerBuildCellSelected(TowerBuildCell cell)
    {
        ShowTowerInfo(cell.tower);
    }

    public void OnTowerBuild(TowerBuildCell cell)
    {
        Hide();
    }

    private void ShowTowerInfo(TowerController tower)
    {
        displayObject.transform.localScale = new Vector3(1, 1, 1);
        var stats = tower.GetTowerStats();
        towerIcon.sprite = stats.towerIcon;
        towerName.text = stats.towerName + " (Level: " + stats.currentLevel.ToString() + ")";
        towerAttackDamage.text = stats.GetCurrentDamage().ToString();
        towerAttackSpeed.text = stats.GetFireSpeed().ToString();
        towerAttackRange.text = stats.fireRange.ToString();
    }

    public void Hide()
    {
        displayObject.transform.localScale = Vector3.zero;
    }
}
