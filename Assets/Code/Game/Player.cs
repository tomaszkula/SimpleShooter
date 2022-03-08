using System;
using TSG.Model;
using UnityEngine;

namespace TSG.Game
{
	public class Player : MonoBehaviour
	{
		[Header("")]
		[SerializeField] TSG_BulletObjectsPool bulletObjectsPool = null;

		private PlayerModel model;
		private float lastTimeShot;

		public PlayerModel Model => model;

        public void Setup(PlayerModel model, GameObject bulletPrefab)
		{
			this.model = model;
			//this.bulletPrefab = bulletPrefab;
		}

		private void Update()
		{
			controlWithNormalInputs();
			controlWithTouchInputs();
		}

		private void controlWithNormalInputs()
        {
			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			{
				MoveLeft();
			}
			else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			{
				MoveRight();
			}

			if (Input.GetKey(KeyCode.Space))
			{
				Shoot();
			}
		}

		private void controlWithTouchInputs()
        {
			if (Input.touchCount < 1)
            {
				return;
            }

			Touch _touch = Input.GetTouch(0);
			Vector2 _touchedPosition = _touch.position;
			Vector2 _normalizedTouchedPosition = normalize(_touchedPosition);

			if (_normalizedTouchedPosition.x < 0.3f)
			{
				MoveLeft();
			}
			else if (_normalizedTouchedPosition.x > 0.7f)
			{
				MoveRight();
			}

			if (_normalizedTouchedPosition.x > 0.4f && _normalizedTouchedPosition.x < 0.6f)
			{
				Shoot();
			}
		}

		private Vector2 normalize(Vector2 _position)
        {
			Vector2 _normalizedPosition = new Vector2(_position.x / Screen.width, _position.y / Screen.height);
			return _normalizedPosition;
        }

		private void MoveLeft()
		{
			var pos = transform.position;
			pos.x -= model.Speed * Time.deltaTime;
			transform.position = pos;
		}

		private void MoveRight()
		{
			var pos = transform.position;
			pos.x += model.Speed * Time.deltaTime;
			transform.position = pos;
		}

		private void Shoot()
		{
			if (lastTimeShot + model.BulletCooldown <= Time.timeSinceLevelLoad)
			{
				Bullet _bullet = bulletObjectsPool.Get();
				_bullet.transform.position = transform.position;
				_bullet.transform.rotation = Quaternion.identity;
				_bullet.Setup(gameObject);
				//bullet.Setup(model.BulletSpeed, model.BulletDamage);
				lastTimeShot = Time.timeSinceLevelLoad;
			}
		}
	}
}