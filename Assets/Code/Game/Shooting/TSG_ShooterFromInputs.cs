using TSG.Game;
using UnityEngine;

public class TSG_ShooterFromInputs : MonoBehaviour, TSG_IShooter
{
	[Header("Properties")]
	[SerializeField] TSG_BulletConfig defaultBulletConfig = null;
	[SerializeField] TSG_ShootingPattern defaultShootingPattern = null;

    float shootDelay = 0f;
	TSG_BulletConfig bulletConfig = null;
	TSG_ShootingPattern shootingPattern = null;

	[Header("References")]
	[SerializeField] Transform bulletsSpawner = null;

	[Header("Events")]
	[SerializeField] TSG_GameEvent onBulletSelect = null;
	[SerializeField] TSG_GameEvent onShootingPatternChangeEvent = null;

    private void Start()
    {
		setBulletConfig(defaultBulletConfig, true);
		setShootingPattern(defaultShootingPattern, true);
	}

	public void OnBulletSellect(TSG_GameEventData _gameEventData)
	{
		TSG_BulletConfig _bulletConfig = _gameEventData.ScriptableObjectValues[0] as TSG_BulletConfig;
		setBulletConfig(_bulletConfig, false);
	}

	public void OnShootingPatternChange(TSG_GameEventData _gameEventData)
	{
		TSG_ShootingPattern _shootingPattern = _gameEventData.ScriptableObjectValues[0] as TSG_ShootingPattern;
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

	private void setBulletConfig(TSG_BulletConfig _bulletConfig, bool _shouldBroadcast)
	{
		bulletConfig = _bulletConfig;

		if (_shouldBroadcast)
		{
			onBulletSelect?.Invoke(new TSG_GameEventData()
			{
				ScriptableObjectValues = new ScriptableObject[] { bulletConfig }
			});
		}
	}

	private void setShootingPattern(TSG_ShootingPattern _shootingPattern, bool _shouldBroadcast)
	{
		shootingPattern = _shootingPattern;

		if (_shouldBroadcast)
		{
			onShootingPatternChangeEvent?.Invoke(new TSG_GameEventData()
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
