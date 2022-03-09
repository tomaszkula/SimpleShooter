using TSG.Game;
using UnityEngine;

public class TSG_AutoShooter : MonoBehaviour, TSG_IShooter
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

    public void Shoot()
    {
        if (shotDelay > 0f)
        {
            shotDelay -= Time.deltaTime;
        }
        else
        {
            shotDelay = shotCooldown.Random;

            TSG_Bullet _bullet = bulletObjectsPool.Get();
            _bullet.transform.position = bulletsSpawner.position;
            _bullet.transform.forward = bulletsSpawner.forward;
            _bullet.Setup(gameObject);
        }
    }
}
