using UnityEngine;

public class SS_ExplosiveAttacker : MonoBehaviour, SS_IAttackable
{
    [Header("Variables")]
    [SerializeField] SS_AttackerConfig attackerConfig = null;
    [SerializeField] float explosionRange = 0f;
    [SerializeField] SS_ObjectsPool particleObjectsPool = null;

    Collider[] explosionTargetColliders = new Collider[10];

    [Header("Components")]
    Transform myTransform = null;
    SS_IDestroyable iDestroyable = null;

    private void Awake()
    {
        myTransform = transform;
        iDestroyable = GetComponent<SS_IDestroyable>();
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
        SS_IDamageable _targetIDamageable = _targetCollider?.GetComponent<SS_IDamageable>();
        if(_targetIDamageable == null)
        {
            return;
        }

        int _targetsCount = Physics.OverlapSphereNonAlloc(myTransform.position, explosionRange, explosionTargetColliders);
        for (int i = 0; i < _targetsCount; i++)
        {
            Collider _explosionTargetCollider = explosionTargetColliders[i];
            if(_attacker.transform.IsChildOf(_explosionTargetCollider.transform))
            {
                continue;
            }

            SS_IDamageable _iDamageable = _explosionTargetCollider?.GetComponent<SS_IDamageable>();
            _iDamageable?.Damage(attackerConfig.DamageType, attackerConfig.Damage, gameObject, _attacker, _targetCollider.ClosestPoint(myTransform.position));
        }

        SS_Particle _particle = particleObjectsPool?.Get()?.GetComponent<SS_Particle>();
        if (_particle != null)
        {
            _particle.transform.position = myTransform.position;
            _particle.Play();
        }

        if (iDestroyable != null)
        {
            iDestroyable.Destroy();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
