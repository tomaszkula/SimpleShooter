using UnityEngine;

namespace TSG.Game
{
    public class TSG_Bullet : MonoBehaviour
	{
		[Header("Variables")]
		[SerializeField] TSG_BulletConfig bulletConfig = null;

		GameObject attacker = null;

		[Header("Components")]
		Transform myTransform = null;
		Rigidbody myRigidbody = null;

		private void Awake()
		{
			myTransform = GetComponent<Transform>();
			myRigidbody = GetComponent<Rigidbody>();
		}

        private void OnTriggerEnter(Collider _other)
        {
			TSG_IDamageable _iDamageable = _other?.GetComponent<TSG_IDamageable>();
			if(_iDamageable == null)
            {
				return;
            }

			bool _didDamage = _iDamageable.Damage(bulletConfig.DamageType, bulletConfig.Damage, gameObject, attacker, _other.ClosestPoint(myTransform.position));
			if(_didDamage)
            {
				Destroy(gameObject);
            }
		}

		public void Setup(GameObject _attacker)
		{
			attacker = _attacker;

			myRigidbody.velocity = bulletConfig.MoveSpeed * myTransform.forward;
		}
	}
}