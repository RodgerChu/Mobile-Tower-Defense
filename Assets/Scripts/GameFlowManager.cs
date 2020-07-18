using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameFlowManager : MonoBehaviour
{
    public PoolableObject[] poolableObjects;

    public WaveSO[] waves;

    public Transform enemySpawnPoint;
    public Transform[] waypoints;

    public uint defaultHealth = 5;

    public UnityEvent OnWaveEnded;

    private uint currentHealth;

    private uint completedCoroutines = 0;

    void Start()
    {
        currentHealth = defaultHealth;

        PoolManager.Initialize();

        for (int index = 0; index < poolableObjects.Length; index++)
        {
            var poolableObject = poolableObjects[index];
            PoolManager.AddToPool(poolableObject);
        }

        GameEventObserver.AddOnDamageTakenListener(OnDamageTaken);

        StartCoroutine(SpawnCoroutine());
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
        for (int index = 0; index < waves.Length; index++)
        {
            completedCoroutines = 0;

            var wave = waves[index];
            List<IEnumerator> enemiesSpawnCoroutine = new List<IEnumerator>();

            foreach (var data in wave.enemySpawnDatas)
            {
                var spawnCoroutine = EnemySpawnCoroutine(data);                
                StartCoroutine(spawnCoroutine);
                enemiesSpawnCoroutine.Add(spawnCoroutine);
            }

            while(completedCoroutines != enemiesSpawnCoroutine.Count)
            {
                Debug.Log("Waiting: current completed – " + completedCoroutines + " total number –" + enemiesSpawnCoroutine.Count);
                yield return new WaitForSeconds(0.1f);
            }


            OnWaveEnded?.Invoke();

            foreach (var coroutine in enemiesSpawnCoroutine)
            {
                StopCoroutine(coroutine);
            }

            yield return new WaitForSeconds(wave.waitTime);        
        }

        Debug.Log("All waves completed");
    }

    private IEnumerator EnemySpawnCoroutine(EnemySpawnData enemyData)
    {
        Debug.Log("Start coroutine: enemy spawn. Enemy: " + enemyData.enemyPoolable + ". Enemy count:" + enemyData.numberOfEnemies);
        int index = 0;
        if (enemyData.spawnAtWaveStart)
        {
            SpawnEnemy(enemyData.enemyPoolable);
            index++;
            yield return new WaitForSeconds(enemyData.spawnTimeInterval);
        }

        for ( ; index < enemyData.numberOfEnemies; index++)
        {
            SpawnEnemy(enemyData.enemyPoolable);
            yield return new WaitForSeconds(enemyData.spawnTimeInterval);
        }

        completedCoroutines++;
    }

    private void SpawnEnemy(Poolable poolable)
    {
        Debug.Log("Spawn enemy: " + poolable);
        var enemy = PoolManager.GetFromPool(poolable);
        enemy.transform.position = enemySpawnPoint.position;
        var controller = enemy.GetComponent<EnemyController>();
        controller.waypoints = waypoints;
    }
}
