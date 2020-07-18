using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyController : Poolable
{
    public EnemyStats enemyStatsPrefab;
    public Transform[] waypoints;
    public NavMeshAgent agent;
    public Collider triggerCollider;

    public Action<EnemyController> OnKill;

    private int currentWayPoint = 0;
    public EnemyStats currentStats;

    private void Awake()
    {
        currentStats = Instantiate(enemyStatsPrefab);
        currentStats.ResetStats();
    }

    // Start is called before the first frame update
    void Start()
    {
        agent.speed = currentStats.moveSpeed;
        currentStats.OnDeath += OnDeath;
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
                GameEventObserver.FireOnDamageTakenEvent(currentStats.damageToPlayer);
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
        currentStats.ResetStats();
    }

    public void TakeDamage(uint amount)        
    {
        currentStats.TakeDamage(amount);
    }

    private void SetNextPoint()
    {
        if (waypoints == null || waypoints.Length == 0)
        {
            return;
        }
        agent.SetDestination(waypoints[currentWayPoint].position);
        currentWayPoint++;
    }
}
