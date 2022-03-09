using TSG.Game;
using UnityEngine;

public class TSG_AutoShooter : MonoBehaviour, TSG_IShooter
{
    [Header("Variables")]
    [SerializeField] TSG_ShooterConfig shooterConfig = null;

    float shotDelay = 0f;

    [Header("References")]
    [SerializeField] Transform bulletsSpawner = null;

    private void Start()
    {
        shotDelay = shooterConfig.Cooldown.Random;
    }

    public void Shoot()
    {
        if (shotDelay > 0f)
        {
            shotDelay -= Time.deltaTime;
        }
        else
        {
            shotDelay = shooterConfig.Cooldown.Random;

            TSG_Bullet _bullet = shooterConfig.BulletObjectsPool.Get();
            _bullet.transform.position = bulletsSpawner.position;
            _bullet.transform.forward = bulletsSpawner.forward;
            _bullet.Setup(gameObject);
        }
    }
}
