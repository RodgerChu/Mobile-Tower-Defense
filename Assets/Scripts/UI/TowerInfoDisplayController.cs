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

    public void OnTowerSelected(TowerController tower)
    {
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
        Debug.Log("Show tower info");
        displayObject.transform.localScale = new Vector3(1, 1, 1);
        var stats = tower.towerStats;
        towerIcon.sprite = stats.towerIcon;
        towerName.text = stats.towerName;
        towerAttackDamage.text = stats.damage.ToString();
        towerAttackSpeed.text = stats.fireSpeed.ToString();
        towerAttackRange.text = stats.fireRange.ToString();
    }

    private void Hide()
    {
        displayObject.transform.localScale = Vector3.zero;
    }
}
