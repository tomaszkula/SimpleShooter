using Cysharp.Threading.Tasks;
using TSG.Model;
using TSG.Popups;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TSG.Game
{
    public class GameplayController : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] TSG_GameEvent onLevelFail = null;

        [Header("")]
        [SerializeField] private EnemyConfig enemyConfig;
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private SpawnerConfig spawnerConfig;
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private Transform enemySpawnPoint;

        private Player player;
        private float lastTimeSpawnedEnemy;

        private void Start()
        {
            SpawnPlayer();
        }

        private void Update()
        {
            if (player.Model.IsDead())
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
            var playerGo = Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity, transform);
            player = playerGo.GetComponent<Player>();
            player.Setup(new PlayerModel(playerConfig), bulletPrefab);
        }
        
        private void SpawnEnemy()
        {
            var g = MonoBehaviour.Instantiate(spawnerConfig.Prefab, enemySpawnPoint.transform.position,
                Quaternion.identity);
            g.transform.position = enemySpawnPoint.transform.position +
                                   new Vector3(
                                       Random.Range(spawnerConfig.SpawnPosition.x, spawnerConfig.SpawnPosition.y),
                                       0, 0);
            var enemy = g.GetComponent<Enemy>();
            enemy.Setup(new EnemyModel(enemyConfig));
        }

        private void HandlePlayerDeath(Player playerModel)
        {
            
        }

        public void OnPlayerDeath()
        {
            onLevelFail?.Invoke();
        }
    }
}
