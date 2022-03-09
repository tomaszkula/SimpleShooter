using UnityEngine;

namespace TSG.Game
{
    public class TSG_Bullet : MonoBehaviour
	{
		[Header("Variables")]
		GameObject attacker = null;

		[Header("Components")]
		TSG_IMoveable iMoveable = null;
		TSG_IAttackable iAttackable = null;

        private void Awake()
        {
			iMoveable = GetComponent<TSG_IMoveable>();
			iAttackable = GetComponent<TSG_IAttackable>();
		}

        private void Update()
        {
			iMoveable?.Move();
		}

        private void OnTriggerEnter(Collider _other)
        {
			iAttackable?.Attack(_other, attacker);
		}

		public void Setup(GameObject _attacker)
		{
			attacker = _attacker;
		}
	}
}