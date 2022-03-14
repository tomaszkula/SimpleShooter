using UnityEngine;

public class SS_ObjectsPoolsManager : MonoBehaviour
{
    [Header("Variables")]
    SS_ObjectsPool[] objectsPools = new SS_ObjectsPool[0];

    private void Awake()
    {
        objectsPools = Resources.FindObjectsOfTypeAll<SS_ObjectsPool>();
    }

    private void Start()
    {
        for (int i = 0; i < objectsPools.Length; i++)
        {
            objectsPools[i].Init();
        }
    }
}
