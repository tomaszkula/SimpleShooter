using TSG.Game;
using UnityEngine;

public class TSG_AutoShoot : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] TSG_MinMax shotCooldown = new TSG_MinMax(0f, 0f);

    float shotDelay = 0f;

    [Header("References")]
    [SerializeField] Transform bulletsSpawner = null;

    [Header("Objects Pools")]
    [SerializeField] TSG_BulletObjectsPool bulletObjectsPool = null;

    private void Start()
    {
        shotDelay = shotCooldown.Random;
    }

    private void Update()
    {
        checkShotDelay();
        shoot();
    }

    private void checkShotDelay()
    {
        if(shotDelay > 0f)
        {
            shotDelay -= Time.deltaTime;
        }
    }

    private void shoot()
    {
        if(shotDelay > 0f)
        {
            return;
        }

        Bullet _bullet = bulletObjectsPool.Get();
        _bullet.transform.position = bulletsSpawner.position;
        _bullet.transform.forward = bulletsSpawner.forward;
        _bullet.Setup(gameObject);

        shotDelay = shotCooldown.Random;
    }
}
