using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResourceController : MonoBehaviour
{
    public uint startingMoney = 15;
    private uint currentMoney = 0;

    void Start()
    {
        GameEventObserver.FireOnMoneyChangedEvent(startingMoney);
        GameEventObserver.AddOnEnemyKillListener(OnEnemyKill);
        currentMoney = startingMoney;
    }

    private void OnEnemyKill(EnemyController enemy)
    {
        currentMoney += enemy.enemyStatsPrefab.bounty;
        GameEventObserver.FireOnMoneyChangedEvent(currentMoney);
    }

    public uint GetCurrentMoney()
    {
        return currentMoney;
    }

    public void DecreaseMoney(uint decreaseAmount)
    {
        currentMoney -= decreaseAmount;
        GameEventObserver.FireOnMoneyChangedEvent(currentMoney);
    }

    public void IncreaseMoney(uint increaseAmount)
    {
        currentMoney += increaseAmount;
        GameEventObserver.FireOnMoneyChangedEvent(currentMoney);
    }
}
