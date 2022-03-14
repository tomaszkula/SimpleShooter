using UnityEngine;

public abstract class SS_ShootingPattern : ScriptableObject
{
    public abstract void ApplyShootingPattern(GameObject _caller, SS_BulletConfig _bulletConfig, Transform _bulletsSpawner);
}
