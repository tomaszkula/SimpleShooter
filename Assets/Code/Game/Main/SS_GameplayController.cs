using UnityEngine;

public class SS_GameplayController : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] SS_SpawnerConfig spawnerConfig = null;

    bool isPlayerDead = false;
    float lastTimeSpawnedEnemy = 0f;

    [Header("References")]
    [SerializeField] Transform playerSpawnPoint = null;
    [SerializeField] Transform enemySpawnPoint = null;

    [Header("Events")]
    [SerializeField] SS_GameEvent onLevelFail = null;

    [Header("Objects Pools")]
    [SerializeField] SS_ObjectsPool playerObjectsPool = null;
        
    private void Start()
    {
        spawnPlayer();
    }

    private void Update()
    {
        if (isPlayerDead)
        {
            return;
        }

        if (lastTimeSpawnedEnemy + spawnerConfig.SpawnDelay <= Time.timeSinceLevelLoad)
        {
            lastTimeSpawnedEnemy = Time.timeSinceLevelLoad;
            spawnEnemy();
        }
    }

    public void OnPlayerDeath()
    {
        isPlayerDead = true;
        onLevelFail?.Invoke();
    }

    private void spawnPlayer()
    {
        SS_Player _player = playerObjectsPool?.Get()?.GetComponent<SS_Player>();
        if (_player != null)
        {
            _player.transform.position = playerSpawnPoint.position;
            _player.transform.forward = playerSpawnPoint.forward;
        }
    }
        
    private void spawnEnemy()
    {
        SS_ObjectsPool _randomEnemyObjectsPool = spawnerConfig?.GetRandomEnemyObjectsPool();
        SS_Enemy _enemy = _randomEnemyObjectsPool?.Get()?.GetComponent<SS_Enemy>();
        if (_enemy != null)
        {
            _enemy.transform.position = enemySpawnPoint.transform.position + new Vector3(spawnerConfig.XSpawnPositionRange.Random, 0, 0);
            _enemy.transform.forward = enemySpawnPoint.forward;
        }
    }
}