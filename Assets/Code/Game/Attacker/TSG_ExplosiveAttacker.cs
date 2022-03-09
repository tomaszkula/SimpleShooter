using UnityEngine;

public class TSG_ExplosiveAttacker : MonoBehaviour, TSG_IAttackable
{
    [Header("Variables")]
    [SerializeField] TSG_AttackerConfig attackerConfig = null;
    [SerializeField] float explosionRange = 0f;

    Collider[] explosionTargetColliders = new Collider[10];

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
        int _targetsCount = Physics.OverlapSphereNonAlloc(myTransform.position, explosionRange, explosionTargetColliders);
        for (int i = 0; i < _targetsCount; i++)
        {
            Collider _explosionTargetCollider = explosionTargetColliders[i];
            if(_attacker.transform.IsChildOf(_explosionTargetCollider.transform))
            {
                continue;
            }

            TSG_IDamageable _iDamageable = _explosionTargetCollider?.GetComponent<TSG_IDamageable>();
            _iDamageable?.Damage(attackerConfig.DamageType, attackerConfig.Damage, gameObject, _attacker, _targetCollider.ClosestPoint(myTransform.position));
        }

        if (iDestroyable != null)
        {
            iDestroyable.Destroy();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
