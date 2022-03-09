using UnityEngine;

public class TSG_PlayerHealth : MonoBehaviour, TSG_IHurtable
{
    [SerializeField] float defaultHealth = 0f;

    float health = 0f;

    [Header("Events")]
    [SerializeField] TSG_GameEvent onHealthUpdate = null;
    [SerializeField] TSG_GameEvent onPlayerDamaged = null;
    [SerializeField] TSG_GameEvent onPlayerDeath = null;

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
        Destroy(gameObject);

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
