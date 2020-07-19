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
    public uint bonusDamageWithLevelAmount;
    public float fireSpeedIncreaseWithLevelAmount;

    public Poolable poolableProjectile;

    public uint currentLevel = 1;

    public void IncreaseLevel()
    {
        currentLevel++;
    }

    public uint GetCurrentDamage()
    {
        return damage + currentLevel * bonusDamageWithLevelAmount;
    }

    public float GetFireSpeed()
    {
        var speed = fireSpeed - currentLevel * fireSpeedIncreaseWithLevelAmount;
        if (speed < 0.1f)
        {
            speed = 0.1f;
        }

        return speed;
    }
}
