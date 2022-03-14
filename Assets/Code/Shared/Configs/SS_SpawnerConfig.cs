using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "spawnerConfig_NewSpawnerConfig", menuName = "TSG/Configs/Spawner Config")]
public class SS_SpawnerConfig : ScriptableObject
{
    public List<SS_ObjectsPool> EnemyObjectsPools = new List<SS_ObjectsPool>();
    public float SpawnDelay = 0f;
    public SS_MinMax XSpawnPositionRange = new SS_MinMax(0f, 0f);

    public SS_ObjectsPool GetRandomEnemyObjectsPool()
    {
        if(EnemyObjectsPools == null || EnemyObjectsPools.Count < 1)
        {
            return null;
        }

        int _enemyObjectsPoolId = Random.Range(0, EnemyObjectsPools.Count);
        return EnemyObjectsPools[_enemyObjectsPoolId];
    }
}
