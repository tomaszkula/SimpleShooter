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
        [SerializeField] TSG_EnemyObjectsPool enemyObjectsPool = null;
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
            SpawnPlayer();
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
                SpawnEnemy();
            }
        }

        private void SpawnPlayer()
        {
            TSG_Player _player = playerObjectsPool.Get();
            _player.transform.position = playerSpawnPoint.position;
            _player.transform.rotation = playerSpawnPoint.rotation;
        }
        
        private void SpawnEnemy()
        {
            TSG_Enemy _enemy = enemyObjectsPool.Get();
            _enemy.transform.position = enemySpawnPoint.transform.position +
                new Vector3(Random.Range(spawnerConfig.SpawnPosition.x, spawnerConfig.SpawnPosition.y), 0, 0);
            _enemy.transform.rotation = Quaternion.identity;
        }

        public void OnPlayerDeath()
        {
            isPlayerDead = true;
            onLevelFail?.Invoke();
        }
    }
}
