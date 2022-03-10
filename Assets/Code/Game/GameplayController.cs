using UnityEngine;

namespace TSG.Game
{
    public class GameplayController : MonoBehaviour
    {
        [Header("Variables")]
        [SerializeField] TSG_SpawnerConfig spawnerConfig = null;

        bool isPlayerDead = false;
        float lastTimeSpawnedEnemy = 0f;

        [Header("References")]
        [SerializeField] Transform playerSpawnPoint = null;
        [SerializeField] Transform enemySpawnPoint = null;

        [Header("Events")]
        [SerializeField] TSG_GameEvent onLevelFail = null;

        [Header("Objects Pools")]
        [SerializeField] TSG_ObjectsPool playerObjectsPool = null;
        
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
            TSG_Player _player = playerObjectsPool?.Get()?.GetComponent<TSG_Player>();
            if (_player != null)
            {
                _player.transform.position = playerSpawnPoint.position;
                _player.transform.forward = playerSpawnPoint.forward;
            }
        }
        
        private void spawnEnemy()
        {
            TSG_ObjectsPool _randomEnemyObjectsPool = spawnerConfig?.GetRandomEnemyObjectsPool();
            TSG_Enemy _enemy = _randomEnemyObjectsPool?.Get()?.GetComponent<TSG_Enemy>();
            if (_enemy != null)
            {
                _enemy.transform.position = enemySpawnPoint.transform.position + new Vector3(spawnerConfig.XSpawnPositionRange.Random, 0, 0);
                _enemy.transform.forward = enemySpawnPoint.forward;
            }
        }
    }
}
