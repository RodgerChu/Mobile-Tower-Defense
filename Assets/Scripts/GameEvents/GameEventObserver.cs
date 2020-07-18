using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GameEventObserver
{
    private static Action<EnemyController> OnEnemyKill;
    private static Action<uint> OnDamageTaken;
    private static Action<uint> OnMoneyChanged;
    private static Action<uint> HUDHealthEvent;

    #region OnEnemyKill

    public static void AddOnEnemyKillListener(Action<EnemyController> listener)
    {
        OnEnemyKill += listener;
    }

    public static void RemoveOnEnemyKillListener(Action<EnemyController> listener)
    {
        OnEnemyKill -= listener;
    }

    public static void FireEnemyKillEvent(EnemyController enemy)
    {
        OnEnemyKill?.Invoke(enemy);
    }

    #endregion

    #region OnDamageTaken

    public static void AddOnDamageTakenListener(Action<uint> listener)
    {
        OnDamageTaken += listener;
    }

    public static void RemoveOnDamageTakenListener(Action<uint> listener)
    {
        OnDamageTaken -= listener;
    }

    public static void FireOnDamageTakenEvent(uint damange)
    {
        OnDamageTaken?.Invoke(damange);
    }

    #endregion

    #region HUDHealthEvent

    public static void AddHUDHealthEventListener(Action<uint> listener)
    {
        HUDHealthEvent += listener;
    }

    public static void RemoveHUDHealthEventListener(Action<uint> listener)
    {
        HUDHealthEvent -= listener;
    }

    public static void FireHUDHealthEvent(uint damange)
    {
        HUDHealthEvent?.Invoke(damange);
    }

    #endregion

    #region OnMOneyChanged

    public static void AddOnMOneyChangedListener(Action<uint> listener)
    {
        OnMoneyChanged += listener;
    }

    public static void RemoveOnMOneyChangedListener(Action<uint> listener)
    {
        OnMoneyChanged -= listener;
    }

    public static void FireOnMoneyChangedEvent(uint newAmount)
    {
        OnMoneyChanged?.Invoke(newAmount);
    }

    #endregion
}
