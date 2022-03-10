using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "spawnerConfig_NewSpawnerConfig", menuName = "TSG/Configs/Spawner Config")]
public class TSG_SpawnerConfig : ScriptableObject
{
    public List<TSG_ObjectsPool> EnemyObjectsPools = new List<TSG_ObjectsPool>();
    public float SpawnDelay = 0f;
    public TSG_MinMax XSpawnPositionRange = new TSG_MinMax(0f, 0f);

    public TSG_ObjectsPool GetRandomEnemyObjectsPool()
    {
        if(EnemyObjectsPools == null || EnemyObjectsPools.Count < 1)
        {
            return null;
        }

        int _enemyObjectsPoolId = Random.Range(0, EnemyObjectsPools.Count);
        return EnemyObjectsPools[_enemyObjectsPoolId];
    }
}
