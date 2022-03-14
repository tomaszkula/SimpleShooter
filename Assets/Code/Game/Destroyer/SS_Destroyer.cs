using UnityEngine;

public class SS_Destroyer : MonoBehaviour, SS_IDestroyable
{
    [SerializeField] SS_ObjectsPool objectsPool = null;

    public void Destroy()
    {
        objectsPool.Release(gameObject);
    }
}
