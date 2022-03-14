using UnityEngine;

public class SS_Bullet : MonoBehaviour
{
	[Header("Variables")]
	GameObject attacker = null;

	[Header("Components")]
	SS_IMoveable iMoveable = null;
	SS_IAttackable iAttackable = null;

    private void Awake()
    {
		iMoveable = GetComponent<SS_IMoveable>();
		iAttackable = GetComponent<SS_IAttackable>();
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