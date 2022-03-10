using UnityEngine;

public class TSG_ObjectsPoolsManager : MonoBehaviour
{
    [Header("Variables")]
    TSG_ObjectsPool[] objectsPools = new TSG_ObjectsPool[0];

    private void Awake()
    {
        objectsPools = Resources.FindObjectsOfTypeAll<TSG_ObjectsPool>();
    }

    private void Start()
    {
        for (int i = 0; i < objectsPools.Length; i++)
        {
            objectsPools[i].Init();
        }
    }
}
