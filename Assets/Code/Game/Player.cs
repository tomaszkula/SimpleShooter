using System;
using TSG.Model;
using UnityEngine;

namespace TSG.Game
{
	public class Player : MonoBehaviour
	{
		[Header("Events")]
		[SerializeField] TSG_GameEvent onHealthUpdate = null;

		public event Action<Player> onDie = delegate { };

		private PlayerModel model;
		private GameObject bulletPrefab;
		private float lastTimeShot;

		public PlayerModel Model => model;

        private void Start()
        {
			updateHealth();
		}

        public void Setup(PlayerModel model, GameObject bulletPrefab)
		{
			this.model = model;
			this.bulletPrefab = bulletPrefab;
			model.die += OnModelDie;
		}

		private void OnModelDie(PlayerModel obj)
		{
			onDie(this);
		}

		public void TakeDamage(float damage)
		{
			model.TakeDamage(damage);
			updateHealth();
		}

		private void updateHealth()
        {
			onHealthUpdate?.Invoke(new TSG_GameEventData()
			{
				FloatValues = new float[] { model.HitPoints }
			});
		}

		private void Update()
		{
			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			{
				MoveLeft();
			}
			else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			{
				MoveRight();
			}

			if (Input.GetKeyDown(KeyCode.Space))
			{
				Shoot();
			}
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
				var bulletGo = Instantiate(bulletPrefab, transform.position, Quaternion.identity, null);
				var bullet = bulletGo.GetComponent<Bullet>();
				bullet.Setup(model.BulletSpeed, model.BulletDamage);
				lastTimeShot = Time.timeSinceLevelLoad;
			}
		}
	}
}