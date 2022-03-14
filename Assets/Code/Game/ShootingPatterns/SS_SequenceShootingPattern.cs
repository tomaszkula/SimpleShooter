using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "sequenceShootingPattern_NewSequenceShootingPattern", menuName = "TSG/Shooting Patterns/Sequence")]
public class SS_SequenceShootingPattern : SS_ShootingPattern
{
	[Header("Variables")]
	[SerializeField] int shotsCount = 0;
	[SerializeField] float shotDelay = 0f;

	WaitForSeconds shotWaiter = null;

    private void OnEnable()
    {
		shotWaiter = new WaitForSeconds(shotDelay);
	}

    public override void ApplyShootingPattern(GameObject _caller, SS_BulletConfig _bulletConfig, Transform _bulletsSpawner)
	{
		_caller?.GetComponent<MonoBehaviour>()?.StartCoroutine(shoot(_caller, _bulletConfig, _bulletsSpawner));
	}

	private IEnumerator shoot(GameObject _caller, SS_BulletConfig _bulletConfig, Transform _bulletsSpawner)
    {
        for (int i = 0; i < shotsCount; i++)
        {
			spawnBullet(_caller, _bulletConfig, _bulletsSpawner);
			yield return shotWaiter;
		}
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
