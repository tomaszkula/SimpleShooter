using UnityEngine;

public class TSG_ExplosiveAttacker : MonoBehaviour, TSG_IAttackable
{
    [Header("Variables")]
    [SerializeField] TSG_AttackerConfig attackerConfig = null;
    [SerializeField] float explosionRange = 0f;
    [SerializeField] TSG_ParticleObjectsPool particleObjectsPool = null;

    Collider[] explosionTargetColliders = new Collider[10];

    [Header("Components")]
    Transform myTransform = null;
    TSG_IDestroyable iDestroyable = null;

    private void Awake()
    {
        myTransform = transform;
        iDestroyable = GetComponent<TSG_IDestroyable>();
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawSphere(transform.position, explosionRange);
    }
#endif

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

        TSG_Particle _particle = particleObjectsPool.Get();
        _particle.transform.position = myTransform.position;
        _particle.Play();

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
