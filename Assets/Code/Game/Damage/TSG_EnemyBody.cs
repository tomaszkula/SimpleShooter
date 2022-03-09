using UnityEngine;

public class TSG_EnemyBody : MonoBehaviour, TSG_IDamageable
{
    [Header("Damage")]
    [SerializeField] TSG_DamageType damageType = null;
    [SerializeField] float damage = 0f;

    [Header("Components")]
    Transform myTransform = null;
    TSG_IHurtable iHurtable = null;

    private void Awake()
    {
        myTransform = transform;
        iHurtable = GetComponentInParent<TSG_IHurtable>();
    }

    private void OnTriggerEnter(Collider _other)
    {
        TSG_IDamageable _iDamageable = _other?.GetComponent<TSG_IDamageable>();
        if (_iDamageable == null)
        {
            return;
        }

        _iDamageable.Damage(damageType, damage, gameObject, gameObject, _other.ClosestPoint(myTransform.position));
    }

    public bool Damage(TSG_DamageType _damageType, float _damage, GameObject _inflictor, GameObject _attacker, Vector3 _hitPosition)
    {
        return iHurtable.Hurt(_damage);
    }
}
