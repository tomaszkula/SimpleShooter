using UnityEngine;

public class TSG_Destroyer : MonoBehaviour, TSG_IDestroyable
{
    [SerializeField] TSG_ObjectsPool objectsPool = null;

    public void Destroy()
    {
        objectsPool.Release(gameObject);
    }
}
