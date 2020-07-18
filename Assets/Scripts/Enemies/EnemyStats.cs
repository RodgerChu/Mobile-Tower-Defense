using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Enemy/Stats", order = 0)]
public class EnemyStats: ScriptableObject
{
    public string enemyName = "Enemy";

    public uint maxHealthPoints;
    private uint currentHealthPoints;

    public uint damageToPlayer = 1;
    public uint armor = 0;
    public float moveSpeed = 1;
    public uint bounty = 3;

    public Action OnDeath;

    public void TakeDamage(uint amount)
    {
        amount -= armor;
        if (amount <= 0)
            amount = 1;

        if (currentHealthPoints != 0)
        {
            currentHealthPoints -= amount;
        }
        
        if (currentHealthPoints == 0)
        {
            OnDeath?.Invoke();
        }
    }

    public void ResetStats()
    {
        currentHealthPoints = maxHealthPoints;
    }
}
