using UnityEngine;

[CreateAssetMenu(fileName = "defaultShootingPattern_NewDefaultShootingPattern", menuName = "TSG/Shooting Patterns/Default")]
public class SS_DefaultShootingPattern : SS_ShootingPattern
{
	public override void ApplyShootingPattern(GameObject _caller, SS_BulletConfig _bulletConfig, Transform _bulletsSpawner)
	{
		spawnBullet(_caller, _bulletConfig, _bulletsSpawner);
	}

	private void spawnBullet(GameObject _caller, SS_BulletConfig _bulletConfig, Transform _bulletsSpawner)
	{
		SS_Bullet _bullet = _bulletConfig?.BulletObjectsPool?.Get()?.GetComponent<SS_Bullet>();
		if (_bullet != null)
		{
			_bullet.transform.position = _bulletsSpawner.position;
			_bullet.transform.forward = _bulletsSpawner.forward;
			_bullet.Setup(_caller);
		}
	}
}
