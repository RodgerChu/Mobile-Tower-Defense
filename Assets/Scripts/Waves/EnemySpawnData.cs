using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnData", menuName = "Wave/EnemySpawnData", order = 1)]
public class EnemySpawnData : ScriptableObject
{
    public Poolable enemyPoolable;
    public float spawnTimeInterval = 1;
    public uint numberOfEnemies = 1;
    public bool spawnAtWaveStart = true;
}
