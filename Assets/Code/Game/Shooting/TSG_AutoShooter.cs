using TSG.Game;
using UnityEngine;

public class TSG_AutoShooter : MonoBehaviour, TSG_IShooter
{
    [Header("Variables")]
    [SerializeField] TSG_BulletConfig bulletConfig = null;
    [SerializeField] TSG_ShootingPattern shootingPattern = null;

    float shotDelay = 0f;

    [Header("References")]
    [SerializeField] Transform bulletsSpawner = null;

    private void Start()
    {
        shotDelay = bulletConfig.Cooldown.Random;
    }

    public void Shoot()
    {
        if (shotDelay > 0f)
        {
            shotDelay -= Time.deltaTime;
        }
        else
        {
            shotDelay = bulletConfig.Cooldown.Random;
            shootingPattern?.ApplyShootingPattern(gameObject, bulletConfig, bulletsSpawner);
        }
    }
}
