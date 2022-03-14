using UnityEngine;

public class SS_PlayerBody : MonoBehaviour, SS_IDamageable
{
    [Header("Components")]
    SS_IHurtable iHurtable = null;

    private void Awake()
    {
        iHurtable = GetComponentInParent<SS_IHurtable>();
    }

    public bool Damage(SS_DamageType _damageType, float _damage, GameObject _inflictor, GameObject _attacker, Vector3 _hitPosition)
    {
        return iHurtable.Hurt(_damage);
    }
}
