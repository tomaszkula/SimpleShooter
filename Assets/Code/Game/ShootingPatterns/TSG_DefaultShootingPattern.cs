using TSG.Game;
using UnityEngine;

[CreateAssetMenu(fileName = "defaultShootingPattern_NewDefaultShootingPattern", menuName = "TSG/Shooting Patterns/Default")]
public class TSG_DefaultShootingPattern : TSG_ShootingPattern
{
	public override void ApplyShootingPattern(GameObject _caller, TSG_BulletConfig _bulletConfig, Transform _bulletsSpawner)
	{
		spawnBullet(_caller, _bulletConfig, _bulletsSpawner);
	}

	private void spawnBullet(GameObject _caller, TSG_BulletConfig _bulletConfig, Transform _bulletsSpawner)
	{
		TSG_Bullet _bullet = _bulletConfig?.BulletObjectsPool?.Get()?.GetComponent<TSG_Bullet>();
		if (_bullet != null)
		{
			_bullet.transform.position = _bulletsSpawner.position;
			_bullet.transform.forward = _bulletsSpawner.forward;
			_bullet.Setup(_caller);
		}
	}
}
