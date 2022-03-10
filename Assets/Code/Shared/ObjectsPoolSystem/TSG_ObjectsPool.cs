using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "objectsPool_NewObjectsPool", menuName = "TSG/Objects Pool")]
public class TSG_ObjectsPool : ScriptableObject
{
    [Header("Variables")]
    [SerializeField] GameObject prefab = null;
    [SerializeField] int countToSpawnOnInit = 0;

    Queue<GameObject> instances = new Queue<GameObject>();

    public GameObject Prefab => prefab;

    public void Init()
    {
        for (int i = 0; i < countToSpawnOnInit; i++)
        {
            createNewInstance();
        }
    }

    public GameObject Get()
    {
        if(instances.Count < 1)
        {
            createNewInstance();
        }

        if (instances.Count < 1)
        {
            return null;
        }

        GameObject _instance = instances.Dequeue();
        if(_instance == null)
        {
            return Get();
        }

        _instance.SetActive(true);
        return _instance;
    }

    public void Release(GameObject _instance)
    {
        if(_instance == null)
        {
            return;
        }

        _instance.SetActive(false);
        instances.Enqueue(_instance);
    }

    private void createNewInstance()
    {
        if(prefab == null)
        {
            return;
        }

        GameObject _instance = Instantiate(prefab);
        _instance.SetActive(false);
        instances.Enqueue(_instance);
    }
}
