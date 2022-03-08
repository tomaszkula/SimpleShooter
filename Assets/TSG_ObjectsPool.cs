using System.Collections.Generic;
using UnityEngine;

public class TSG_ObjectsPool<T> : ScriptableObject where T : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] T prefab = null;
    [SerializeField] int countToSpawnOnInit = 0;

    Queue<T> instances = new Queue<T>();

    public void Init()
    {
        for (int i = 0; i < countToSpawnOnInit; i++)
        {
            createNewInstance();
        }
    }

    public T Get()
    {
        if(instances.Count < 1)
        {
            createNewInstance();
        }

        return instances.Dequeue();
    }

    public void Release(T _instance)
    {
        instances.Enqueue(_instance);
    }

    private void createNewInstance()
    {
        T _instance = Instantiate(prefab);
        instances.Enqueue(_instance);
    }
}
