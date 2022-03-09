using TSG.Game;
using UnityEngine;

public class TSG_ShooterFromInputs : MonoBehaviour, TSG_IShooter
{
    [Header("Variables")]
    [SerializeField] float shootCooldown = 0f;

    float shootDelay = 0f;

	[Header("References")]
	[SerializeField] Transform bulletsSpawner = null;

	[Header("Objects Pools")]
    [SerializeField] TSG_BulletObjectsPool bulletObjectsPool = null;

    public void Shoot()
    {
		if (shootDelay > 0f)
		{
			shootDelay -= Time.deltaTime;
		}

		moveByNormalInputs();
		moveByTouchInputs();
	}

	private void moveByNormalInputs()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			shoot();
		}
	}

	private void moveByTouchInputs()
	{
		if (Input.touchCount < 1)
		{
			return;
		}

		Touch _touch = Input.GetTouch(0);
		Vector2 _touchPosition = _touch.position;
		Vector2 _normalizedTouchPosition = normalizeTouchPosition(_touchPosition);

		if (_normalizedTouchPosition.x > 0.4f && _normalizedTouchPosition.x < 0.6f)
		{
			shoot();
		}
	}

	private void shoot()
    {
		if(shootDelay > 0f)
        {
			return;
        }

		shootDelay = shootCooldown;

		TSG_Bullet _bullet = bulletObjectsPool.Get();
		_bullet.transform.position = bulletsSpawner.position;
		_bullet.transform.forward = bulletsSpawner.forward;
		_bullet.Setup(gameObject);
	}

	private Vector2 normalizeTouchPosition(Vector2 _touchPosition)
	{
		Vector2 _normalizedTouchPosition = new Vector2(_touchPosition.x / Screen.width, _touchPosition.y / Screen.height);
		return _normalizedTouchPosition;
	}
}
