using UnityEngine;

public class SS_ShooterFromInputs : MonoBehaviour, SS_IShooter
{
	[Header("Properties")]
	[SerializeField] SS_BulletConfig defaultBulletConfig = null;
	[SerializeField] SS_ShootingPattern defaultShootingPattern = null;

    float shootDelay = 0f;
	SS_BulletConfig bulletConfig = null;
	SS_ShootingPattern shootingPattern = null;

	[Header("References")]
	[SerializeField] Transform bulletsSpawner = null;

	[Header("Events")]
	[SerializeField] SS_GameEvent onBulletChangeEvent = null;
	[SerializeField] SS_GameEvent onShootingPatternChangeEvent = null;

    private void Start()
    {
		setBulletConfig(defaultBulletConfig, true);
		setShootingPattern(defaultShootingPattern, true);
	}

	public void OnBulletChange(SS_GameEventData _gameEventData)
	{
		SS_BulletConfig _bulletConfig = _gameEventData.ScriptableObjectValues[0] as SS_BulletConfig;
		setBulletConfig(_bulletConfig, false);
	}

	public void OnShootingPatternChange(SS_GameEventData _gameEventData)
	{
		SS_ShootingPattern _shootingPattern = _gameEventData.ScriptableObjectValues[0] as SS_ShootingPattern;
		setShootingPattern(_shootingPattern, false);
	}

	public void Shoot()
    {
		manageShootDelay();
		shootByNormalInputs();
		shootByTouchInputs();
	}

	private void manageShootDelay()
    {
		if (shootDelay > 0f)
		{
			shootDelay -= Time.deltaTime;
		}
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
			return;
        }

		shootDelay = bulletConfig.Cooldown.Random;
		shootingPattern?.ApplyShootingPattern(gameObject, bulletConfig, bulletsSpawner);
	}

	private void setBulletConfig(SS_BulletConfig _bulletConfig, bool _shouldBroadcast)
	{
		bulletConfig = _bulletConfig;

		if (_shouldBroadcast)
		{
			onBulletChangeEvent?.Invoke(new SS_GameEventData()
			{
				ScriptableObjectValues = new ScriptableObject[] { bulletConfig }
			});
		}
	}

	private void setShootingPattern(SS_ShootingPattern _shootingPattern, bool _shouldBroadcast)
	{
		shootingPattern = _shootingPattern;

		if (_shouldBroadcast)
		{
			onShootingPatternChangeEvent?.Invoke(new SS_GameEventData()
			{
				ScriptableObjectValues = new ScriptableObject[] { shootingPattern }
			});
		}
	}

	private Vector2 normalizeTouchPosition(Vector2 _touchPosition)
	{
		Vector2 _normalizedTouchPosition = new Vector2(_touchPosition.x / Screen.width, _touchPosition.y / Screen.height);
		return _normalizedTouchPosition;
	}
}
