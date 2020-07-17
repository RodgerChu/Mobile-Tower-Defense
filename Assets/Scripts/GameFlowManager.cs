using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    public PoolableData[] poolableDatas;
    public Poolable[] poolables;

    public Transform enemySpawnPoint;
    public Transform[] waypoints;

    public Poolable enemyPrefab;

    public float spawnTime = 5f;

    public uint defaultHealth = 5;
    private uint currentHealth;

    void Start()
    {
        currentHealth = defaultHealth;

        PoolManager.Initialize();

        for (int index = 0; index < poolableDatas.Length; index++)
        {
            var data = poolableDatas[index];
            var poolable = poolables[index];

            PoolManager.AddToPool(data, poolable);
        }

        GameEventObserver.AddOnDamageTakenListener(OnDamageTaken);

        //StartCoroutine(SpawnCoroutine());
        GameEventObserver.FireHUDHealthEvent(currentHealth);
    }

    private void OnDamageTaken(uint amount)
    {
        if (currentHealth == 1 || currentHealth == 0)
        {
            currentHealth = 0;
        }
        else
        {
            currentHealth -= amount;
        }

        GameEventObserver.FireHUDHealthEvent(currentHealth);
    }

    private IEnumerator SpawnCoroutine()
    {
        while(true)
        {            
            var enemy = PoolManager.GetFromPool(enemyPrefab);
            enemy.transform.position = enemySpawnPoint.position;
            var enemyController = enemy.GetComponent<EnemyController>();
            enemyController.waypoints = waypoints;
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
