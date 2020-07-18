using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuildDisplayController : MonoBehaviour
{
    public TowerBuildCell[] cells;

    public void Hide()
    {
        gameObject.transform.localScale = Vector3.zero;
        foreach (var cell in cells)
        {
            cell.SetUnselected();
        }
    }

    public void Show()
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }
}
