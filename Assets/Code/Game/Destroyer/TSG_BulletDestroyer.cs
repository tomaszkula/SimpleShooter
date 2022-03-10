using TSG.Game;
using UnityEngine;

public class TSG_BulletDestroyer : MonoBehaviour, TSG_IDestroyable
{
    [SerializeField] TSG_BulletObjectsPool bulletObjectsPool = null;

    [Header("Components")]
    TSG_Bullet bullet = null;

    private void Awake()
    {
        bullet = GetComponent<TSG_Bullet>();
    }

    public void Destroy()
    {
        bulletObjectsPool.Release(bullet);
    }
}
