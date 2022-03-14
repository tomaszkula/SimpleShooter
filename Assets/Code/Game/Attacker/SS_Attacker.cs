using UnityEngine;

public class SS_Attacker : MonoBehaviour, SS_IAttackable
{
    [Header("Variables")]
    [SerializeField] SS_AttackerConfig attackerConfig = null;

    [Header("Components")]
    Transform myTransform = null;
    SS_IDestroyable iDestroyable = null;

    private void Awake()
    {
        myTransform = transform;
        iDestroyable = GetComponent<SS_IDestroyable>();
    }

    public void Attack(Collider _targetCollider, GameObject _attacker)
    {
        if (_attacker?.transform?.IsChildOf(_targetCollider?.transform) == true)
        {
            return;
        }

        SS_IDamageable _iDamageable = _targetCollider?.GetComponent<SS_IDamageable>();
        bool? _didDamage = _iDamageable?.Damage(attackerConfig.DamageType, attackerConfig.Damage, gameObject, _attacker, _targetCollider.ClosestPoint(myTransform.position));
        if (_didDamage == true)
        {
            if(iDestroyable != null)
            {
                iDestroyable.Destroy();
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
