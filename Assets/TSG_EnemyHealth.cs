using UnityEngine;

public class TSG_EnemyHealth : MonoBehaviour, TSG_IHurtable
{
    [Header("Variables")]
    [SerializeField] float defaultHealth = 0f;

    float health = 0f;

    [Header("Events")]
    [SerializeField] TSG_GameEvent onEnemyDamaged = null;
    [SerializeField] TSG_GameEvent onEnemyDeath = null;

    private void Start()
    {
        health = defaultHealth;
    }

    public bool Hurt(float _health)
    {
        if(health <= 0f)
        {
            return false;
        }

        health -= _health;
        onEnemyDamaged?.Invoke(new TSG_GameEventData()
        {
            FloatValues = new float[] { _health },
            GameObjectValues = new GameObject[] { gameObject }
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

        onEnemyDeath?.Invoke(new TSG_GameEventData()
        {
            GameObjectValues = new GameObject[] { gameObject }
        });
    }
}
