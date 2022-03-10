using UnityEngine;

public abstract class TSG_ShootingPattern : ScriptableObject
{
    public abstract void ApplyShootingPattern(GameObject _caller, TSG_BulletConfig _bulletConfig, Transform _bulletsSpawner);
}
