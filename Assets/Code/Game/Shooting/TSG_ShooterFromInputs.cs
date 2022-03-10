using TSG.Game;
using UnityEngine;

public class TSG_ShooterFromInputs : MonoBehaviour, TSG_IShooter
{
	[Header("Variables")]
	[SerializeField] TSG_BulletConfig defaultBulletConfig = null;

    float shootDelay = 0f;
	TSG_BulletConfig bulletConfig = null;

	[Header("References")]
	[SerializeField] Transform bulletsSpawner = null;

	[Header("Events")]
	[SerializeField] TSG_GameEvent onBulletSelect = null;

    private void Start()
    {
		setBulletConfig(defaultBulletConfig, true);
	}

    public void OnBulletSellect(TSG_GameEventData _gameEventData)
    {
		TSG_BulletConfig _bulletConfig = _gameEventData.ScriptableObjectValues[0] as TSG_BulletConfig;
		setBulletConfig(_bulletConfig, false);
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

		TSG_Bullet _bullet = bulletConfig?.BulletObjectsPool?.Get()?.GetComponent<TSG_Bullet>();
		if (_bullet != null)
		{
			_bullet.transform.position = bulletsSpawner.position;
			_bullet.transform.forward = bulletsSpawner.forward;
			_bullet.Setup(gameObject);
		}
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

	private Vector2 normalizeTouchPosition(Vector2 _touchPosition)
	{
		Vector2 _normalizedTouchPosition = new Vector2(_touchPosition.x / Screen.width, _touchPosition.y / Screen.height);
		return _normalizedTouchPosition;
	}
}
