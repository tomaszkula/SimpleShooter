using UnityEngine;

public class TSG_Attacker : MonoBehaviour, TSG_IAttackable
{
    [Header("Variables")]
    [SerializeField] TSG_AttackerConfig attackerConfig = null;

    [Header("Components")]
    Transform myTransform = null;
    TSG_IDestroyable iDestroyable = null;

    private void Awake()
    {
        myTransform = transform;
        iDestroyable = GetComponent<TSG_IDestroyable>();
    }

    public void Attack(Collider _targetCollider, GameObject _attacker)
    {
        if (_attacker?.transform?.IsChildOf(_targetCollider?.transform) == true)
        {
            return;
        }

        TSG_IDamageable _iDamageable = _targetCollider?.GetComponent<TSG_IDamageable>();
        bool? _didDamage = _iDamageable?.Damage(attackerConfig.DamageType, attackerConfig.Damage, gameObject, _attacker, _targetCollider.ClosestPoint(myTransform.position));
        if (_didDamage == true)
        {
            if(iDestroyable != null)
            {
                iDestroyable.Destroy();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
