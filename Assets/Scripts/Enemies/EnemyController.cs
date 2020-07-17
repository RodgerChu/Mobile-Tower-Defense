using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyController : Poolable
{
    public EnemyStats enemyStats;
    public Transform[] waypoints;
    public NavMeshAgent agent;
    public Collider triggerCollider;

    public Action<EnemyController> OnKill;

    private int currentWayPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemyStats.ResetStats();

        agent.speed = enemyStats.moveSpeed;
        enemyStats.OnDeath += OnDeath;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (currentWayPoint < waypoints.Length)
            {
                SetNextPoint();
            }
            else
            {
                GameEventObserver.FireOnDamageTakenEvent(enemyStats.damageToPlayer);
                PoolManager.AddToPool(this);
            }

        }
    }

    private void OnDeath()
    {
        OnKill?.Invoke(this);
        GameEventObserver.FireEnemyKillEvent(this);
        PoolManager.AddToPool(this);
    }

    public override void OnMovedToPool()
    {
        triggerCollider.enabled = false;
        triggerCollider.isTrigger = false;
    }

    public override void OnActivatedFromPool()
    {
        triggerCollider.enabled = true;
        triggerCollider.isTrigger = true;
        currentWayPoint = 0;
        enemyStats.ResetStats();
    }

    private void SetNextPoint()
    {
        agent.SetDestination(waypoints[currentWayPoint].position);
        currentWayPoint++;
    }
}
