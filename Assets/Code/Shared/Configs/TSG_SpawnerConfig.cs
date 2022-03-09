using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "spawnerConfig_NewSpawnerConfig", menuName = "TSG/Configs/Spawner Config")]
public class TSG_SpawnerConfig : ScriptableObject
{
    public List<TSG_EnemyObjectsPool> EnemyObjectsPools = new List<TSG_EnemyObjectsPool>();
    public float SpawnDelay = 0f;
    public Vector2 XSpawnPositionRange = Vector2.zero;

    public TSG_EnemyObjectsPool GetRandomEnemyObjectsPool()
    {
        if(EnemyObjectsPools == null || EnemyObjectsPools.Count < 1)
        {
            return null;
        }

        int _enemyObjectsPoolId = Random.Range(0, EnemyObjectsPools.Count);
        return EnemyObjectsPools[_enemyObjectsPoolId];
    }
}
