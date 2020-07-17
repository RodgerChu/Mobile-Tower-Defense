using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResourceController : MonoBehaviour
{
    public const uint startingMoney = 15;
    private uint currentMoney = 0;

    void Start()
    {
        GameEventObserver.AddOnEnemyKillListener(OnEnemyKill);
        currentMoney = startingMoney;
    }

    private void OnEnemyKill(EnemyController enemy)
    {
        currentMoney += enemy.enemyStats.bounty;
        GameEventObserver.FireOnMOneyChangedEvent(currentMoney);
    }

    public uint GetCurrentMoney()
    {
        return currentMoney;
    }

    public void DecreaseMoney(uint decreaseAmount)
    {
        currentMoney -= decreaseAmount;
        GameEventObserver.FireOnMOneyChangedEvent(currentMoney);
    }

}
