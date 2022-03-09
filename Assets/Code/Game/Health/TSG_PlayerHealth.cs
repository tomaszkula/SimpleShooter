using UnityEngine;

public class TSG_PlayerHealth : MonoBehaviour, TSG_IHurtable
{
    [SerializeField] float defaultHealth = 0f;

    float health = 0f;

    [Header("Events")]
    [SerializeField] TSG_GameEvent onHealthUpdate = null;
    [SerializeField] TSG_GameEvent onPlayerDamaged = null;
    [SerializeField] TSG_GameEvent onPlayerDeath = null;

    [Header("Components")]
    TSG_IDestroyable iDestroyable = null;

    private void Awake()
    {
        iDestroyable = GetComponent<TSG_IDestroyable>();
    }

    private void Start()
    {
        health = defaultHealth;
        refreshHealth();
    }

    public bool Hurt(float _health)
    {
        if (health <= 0f)
        {
            return false;
        }

        health -= _health;
        refreshHealth();

        onPlayerDamaged?.Invoke(new TSG_GameEventData()
        {
            FloatValues = new float[] { _health }
        });

        if (health <= 0f)
        {
            die();
        }

        return true;
    }

    private void die()
    {
        if (iDestroyable != null)
        {
            gameObject.SetActive(false);
            iDestroyable.Destroy();
        }
        else
        {
            Destroy(gameObject);
        }

        onPlayerDeath?.Invoke();
    }

    private void refreshHealth()
    {
        onHealthUpdate?.Invoke(new TSG_GameEventData()
        {
            FloatValues = new float[] { health }
        });
    }
}
