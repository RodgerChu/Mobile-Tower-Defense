using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    public GameObject buildTowerMenu;
    public GameObject mangementTowerMenu;

    private void Awake()
    {
        HideTowerMenus();
    }

    public void OnEmptyTowerSpotTap()
    {
        buildTowerMenu.SetActive(true);
        SetMenuAtTapPosition(buildTowerMenu);
    }

    public void OnTowerTap()
    {
        mangementTowerMenu.SetActive(true);
        SetMenuAtTapPosition(mangementTowerMenu);
    }

    public void OnTowerBuild()
    {
        HideTowerMenus();
    }

    private void HideTowerMenus()
    {
        buildTowerMenu.SetActive(false);
        mangementTowerMenu.SetActive(false);
    }

    private void SetMenuAtTapPosition(GameObject menu)
    {
        var position = Input.mousePosition;
        menu.transform.position = position;
    }
}
