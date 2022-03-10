using System.Collections.Generic;
using UnityEngine;

public class TSG_ObjectsPool<T> : ScriptableObject where T : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] T prefab = null;
    [SerializeField] int countToSpawnOnInit = 0;

    Queue<T> instances = new Queue<T>();

    public T Prefab => prefab;

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

        T _instance = instances.Dequeue();
        _instance.gameObject.SetActive(true);
        return _instance;
    }

    public void Release(T _instance)
    {
        if(_instance == null)
        {
            return;
        }

        _instance.gameObject.SetActive(false);
        instances.Enqueue(_instance);
    }

    private void createNewInstance()
    {
        T _instance = Instantiate(prefab);
        instances.Enqueue(_instance);
    }
}
