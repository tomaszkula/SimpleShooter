using UnityEngine;

public class SS_AutoShooter : MonoBehaviour, SS_IShooter
{
    [Header("Variables")]
    [SerializeField] SS_BulletConfig bulletConfig = null;
    [SerializeField] SS_ShootingPattern shootingPattern = null;

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
