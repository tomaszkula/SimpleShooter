using TSG.Game;
using UnityEngine;

public class TSG_ShooterFromInputs : MonoBehaviour, TSG_IShooter
{
	[Header("Variables")]
	[SerializeField] TSG_ShooterConfig shooterConfig = null;

    float shootDelay = 0f;

	[Header("References")]
	[SerializeField] Transform bulletsSpawner = null;

    public void Shoot()
    {
		if (shootDelay > 0f)
		{
			shootDelay -= Time.deltaTime;
		}

		shootByNormalInputs();
		shootByTouchInputs();
	}

	private void shootByNormalInputs()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			shoot();
		}
	}

	private void shootByTouchInputs()
	{
		if (shootDelay > 0f || Input.touchCount < 1)
		{
			return;
		}

        for (int i = 0; i < Input.touchCount; i++)
        {
			Touch _touch = Input.GetTouch(i);
			Vector2 _touchPosition = _touch.position;
			Vector2 _normalizedTouchPosition = normalizeTouchPosition(_touchPosition);

			if (_normalizedTouchPosition.x > 0.4f && _normalizedTouchPosition.x < 0.6f)
			{
				shoot();
			}
		}
	}

	private void shoot()
    {
		if(shootDelay > 0f)
        {
			Debug.Log("No shoot");
			return;
        }

		shootDelay = shooterConfig.Cooldown.Random;

		TSG_Bullet _bullet = shooterConfig.BulletObjectsPool.Get();
		_bullet.transform.position = bulletsSpawner.position;
		_bullet.transform.forward = bulletsSpawner.forward;
		_bullet.Setup(gameObject);

		Debug.Log("Shoot");
	}

	private Vector2 normalizeTouchPosition(Vector2 _touchPosition)
	{
		Vector2 _normalizedTouchPosition = new Vector2(_touchPosition.x / Screen.width, _touchPosition.y / Screen.height);
		return _normalizedTouchPosition;
	}
}
