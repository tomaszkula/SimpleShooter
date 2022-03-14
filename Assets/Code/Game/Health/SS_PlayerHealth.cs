using UnityEngine;

public class SS_PlayerHealth : MonoBehaviour, SS_IHurtable
{
    [SerializeField] float defaultHealth = 0f;

    float health = 0f;

    [Header("Events")]
    [SerializeField] SS_GameEvent onHealthUpdate = null;
    [SerializeField] SS_GameEvent onPlayerDamaged = null;
    [SerializeField] SS_GameEvent onPlayerDeath = null;

    [Header("Components")]
    SS_IDestroyable iDestroyable = null;

    private void Awake()
    {
        iDestroyable = GetComponent<SS_IDestroyable>();
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

        onPlayerDamaged?.Invoke(new SS_GameEventData()
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
            iDestroyable.Destroy();
        }
        else
        {
            gameObject.SetActive(false);
        }

        onPlayerDeath?.Invoke();
    }

    private void refreshHealth()
    {
        onHealthUpdate?.Invoke(new SS_GameEventData()
        {
            FloatValues = new float[] { health }
        });
    }
}
