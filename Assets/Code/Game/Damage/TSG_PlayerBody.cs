using UnityEngine;

public class TSG_PlayerBody : MonoBehaviour, TSG_IDamageable
{
    [Header("Components")]
    TSG_IHurtable iHurtable = null;

    private void Awake()
    {
        iHurtable = GetComponentInParent<TSG_IHurtable>();
    }

    public bool Damage(TSG_DamageType _damageType, float _damage, GameObject _inflictor, GameObject _attacker, Vector3 _hitPosition)
    {
        return iHurtable.Hurt(_damage);
    }
}
