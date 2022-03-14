using UnityEngine;

public class SS_EnemyHealth : MonoBehaviour, SS_IHurtable
{
    [Header("Variables")]
    [SerializeField] float defaultHealth = 0f;

    float health = 0f;

    [Header("Events")]
    [SerializeField] SS_GameEvent onEnemyDamaged = null;
    [SerializeField] SS_GameEvent onEnemyDeath = null;

    [Header("Components")]
    SS_IDestroyable iDestroyable = null;

    private void Awake()
    {
        iDestroyable = GetComponent<SS_IDestroyable>();
    }

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
        onEnemyDamaged?.Invoke(new SS_GameEventData()
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
        if (iDestroyable != null)
        {
            iDestroyable.Destroy();
        }
        else
        {
            gameObject.SetActive(false);
        }

        onEnemyDeath?.Invoke(new SS_GameEventData()
        {
            GameObjectValues = new GameObject[] { gameObject }
        });
    }
}
