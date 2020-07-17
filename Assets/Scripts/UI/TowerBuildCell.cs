using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class TowerBuildCell : MonoBehaviour
{
    public UnityShowTowerInfoEvent OnCellSelected;    
    public UnityBuildTowerEvent OnTowerBuild;

    public TowerController tower;
    public Image towerIcon;
    public TextMeshProUGUI towerCost;

    public Sprite selectedIcon;

    private bool selected = false;

    private void Awake()
    {
        LoadCellWithTower(tower);
    }

    public void LoadCellWithTower(TowerController gObject)
    {
        towerIcon.sprite = gObject.towerStats.towerIcon;
        tower.transform.localPosition = Vector3.zero;
        tower.transform.localScale = new Vector3(35, 35, 35);
        tower.transform.Rotate(0, 120, 0);
        towerCost.text = gObject.towerStats.cost.ToString();
    }

    public void OnPressed()
    {
        if (selected)
        {
            OnTowerBuild?.Invoke(this);
            Debug.Log("Invoked OnTowerBuild");
        }
        else
        {
            OnCellSelected?.Invoke(this);
            Debug.Log("Invoked OnCellSelected");
        }
    }

    public void SetSelected()
    {
        selected = true;
        towerIcon.sprite = selectedIcon;
    }

    public void SetUnselected()
    {
        selected = false;
        towerIcon.sprite = tower.towerStats.towerIcon;
    }
}
