using UnityEngine;

public interface TSG_IDamageable
{
    bool Damage(TSG_DamageType _damageType, float _damage, GameObject _inflictor, GameObject _attacker, Vector3 _hitPosition);
}
