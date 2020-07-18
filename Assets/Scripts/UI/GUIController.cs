using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIController : MonoBehaviour
{
    public TowerBuildDisplayController buildTowerMenu;
    public TowerManagementDisplayController managementTowerMenu;

    private RectTransform buildTowerMenuRectTransform;
    private RectTransform managementTowerMenuRectTransform;

    private void Awake()
    {
        HideTowerMenus();
        buildTowerMenuRectTransform = buildTowerMenu.gameObject.GetComponent<RectTransform>();
        managementTowerMenuRectTransform = managementTowerMenu.gameObject.GetComponent<RectTransform>();
    }

    private void Update()
    {        
        if (Input.GetMouseButtonDown(0))
        {
            var mousePosition = Input.mousePosition;

            if (!IsPointInRT(mousePosition, buildTowerMenu.gameObject.GetComponent<RectTransform>()))
            {
                buildTowerMenu.Hide();
            }

            if (!IsPointInRT(mousePosition, managementTowerMenu.gameObject.GetComponent<RectTransform>()))
            {
                Debug.Log("managementTowerMenu.Hide");
                managementTowerMenu.Hide();
            }
        }
    }

    private bool IsPointInRT(Vector2 point, RectTransform rt)
    {
        Rect rect = rt.rect;
        float leftSide = rt.position.x + rect.xMin;
        float rightSide = rt.position.x + rect.xMax;
        float topSide = rt.position.y + rect.yMax;
        float bottomSide = rt.position.y + rect.yMin;

        Debug.Log("Sides: " + leftSide + " " + rightSide + " " + topSide + " " + bottomSide);
        Debug.Log("Point: " + point);

        return point.x >= leftSide &&
               point.x <= rightSide &&
               point.y >= bottomSide &&
               point.y <= topSide;

    }

    private void OnEmptyTowerSpotTap()
    {
        buildTowerMenu.Show();
        SetMenuAtTapPosition(buildTowerMenu.gameObject);
    }

    private void OnTowerTap(TowerController tower)
    {
        managementTowerMenu.Show(tower);
        SetMenuAtTapPosition(managementTowerMenu.gameObject);
    }

    private void HideTowerMenus()
    {
        buildTowerMenu.Hide();
        managementTowerMenu.Hide();
    }

    private void SetMenuAtTapPosition(GameObject menu)
    {
        var position = Input.mousePosition;
        menu.transform.position = position;
    }

    public void OnTowerSpotTap(TowerSpot spot)
    {
        if (spot.buildedTower == null)
        {
            OnEmptyTowerSpotTap();
        }
        else
        {
            OnTowerTap(spot.buildedTower);
        }
    }

    public void OnTowerBuild()
    {
        HideTowerMenus();
    }
}
