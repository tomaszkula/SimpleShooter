using UnityEngine;

public class SS_EnemyBody : MonoBehaviour, SS_IDamageable
{
    [Header("Damage")]
    [SerializeField] SS_DamageType damageType = null;
    [SerializeField] float damage = 0f;

    [Header("Components")]
    Transform myTransform = null;
    SS_IHurtable iHurtable = null;

    private void Awake()
    {
        myTransform = transform;
        iHurtable = GetComponentInParent<SS_IHurtable>();
    }

    private void OnTriggerEnter(Collider _other)
    {
        SS_IDamageable _iDamageable = _other?.GetComponent<SS_IDamageable>();
        if (_iDamageable == null)
        {
            return;
        }

        _iDamageable.Damage(damageType, damage, gameObject, gameObject, _other.ClosestPoint(myTransform.position));
    }

    public bool Damage(SS_DamageType _damageType, float _damage, GameObject _inflictor, GameObject _attacker, Vector3 _hitPosition)
    {
        return iHurtable.Hurt(_damage);
    }
}
