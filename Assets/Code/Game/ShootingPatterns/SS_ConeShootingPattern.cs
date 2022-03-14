using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "coneShootingPattern_NewConeShootingPattern", menuName = "TSG/Shooting Patterns/Cone")]
public class SS_ConeShootingPattern : SS_ShootingPattern
{
	[Header("Variables")]
	[SerializeField] List<Vector3> offsetSpawnPositions = new List<Vector3>();

	public override void ApplyShootingPattern(GameObject _caller, SS_BulletConfig _bulletConfig, Transform _bulletsSpawner)
	{
        for (int i = 0; i < offsetSpawnPositions.Count; i++)
        {
			spawnBullet(_caller, _bulletConfig, _bulletsSpawner, offsetSpawnPositions[i]);
		}
	}

	private void spawnBullet(GameObject _caller, SS_BulletConfig _bulletConfig, Transform _bulletsSpawner, Vector3 _offsetSpawnPosition)
	{
		SS_Bullet _bullet = _bulletConfig?.BulletObjectsPool?.Get()?.GetComponent<SS_Bullet>();
		if (_bullet != null)
		{
			_bullet.transform.position = _bulletsSpawner.position + _offsetSpawnPosition;
			_bullet.transform.forward = _bulletsSpawner.forward;
			_bullet.Setup(_caller);
		}
	}
}
