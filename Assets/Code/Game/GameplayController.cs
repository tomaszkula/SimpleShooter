using System.Collections.Generic;
using TSG.Model;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TSG.Game
{
    public class GameplayController : MonoBehaviour
    {
        [Header("Variables")]
        bool isPlayerDead = false;
        float lastTimeSpawnedEnemy = 0f;

        [Header("Events")]
        [SerializeField] TSG_GameEvent onLevelFail = null;

        [Header("Objects Pools")]
        [SerializeField] List<TSG_EnemyObjectsPool> enemyObjectsPools = new List<TSG_EnemyObjectsPool>();
        [SerializeField] TSG_PlayerObjectsPool playerObjectsPool = null;

        [Header("Others")]
        [SerializeField] private EnemyConfig enemyConfig;
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private SpawnerConfig spawnerConfig;
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private Transform enemySpawnPoint;

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
            TSG_Player _player = playerObjectsPool.Get();
            _player.transform.position = playerSpawnPoint.position;
            _player.transform.forward = playerSpawnPoint.forward;
        }
        
        private void spawnEnemy()
        {
            TSG_EnemyObjectsPool _randomEnemyObjectsPool = getRandomEnemyObjectsPool();
            TSG_Enemy _enemy = _randomEnemyObjectsPool.Get();
            _enemy.transform.position = enemySpawnPoint.transform.position +
                new Vector3(Random.Range(spawnerConfig.SpawnPosition.x, spawnerConfig.SpawnPosition.y), 0, 0);
            _enemy.transform.forward = enemySpawnPoint.forward;
        }

        private TSG_EnemyObjectsPool getRandomEnemyObjectsPool()
        {
            if(enemyObjectsPools.Count < 1)
            {
                return null;
            }

            int _enemyOnjectsPoolsId = Random.Range(0, enemyObjectsPools.Count);
            return enemyObjectsPools[_enemyOnjectsPoolsId];
        }
    }
}
