using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWave", menuName = "Wave/EnemyWave", order = 1)]
public class WaveSO : ScriptableObject
{
    public EnemySpawnData[] enemySpawnDatas;

    [Tooltip("Time interval before next wave start after last enemy was spawn")]
    public float waitTime = 5f;
}
