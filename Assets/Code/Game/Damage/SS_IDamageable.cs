using UnityEngine;

public interface SS_IDamageable
{
    bool Damage(SS_DamageType _damageType, float _damage, GameObject _inflictor, GameObject _attacker, Vector3 _hitPosition);
}
