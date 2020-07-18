using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "Tower/TowerData", order = 0)]
public class TowerStats : ScriptableObject
{
    public string towerName;
    public Sprite towerIcon;
    public uint cost;
    public uint upgradeCost;
    public float fireRange;
    public float fireSpeed;
    public uint damage;

    public Poolable poolableProjectile;
}
