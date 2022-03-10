using System.Collections.Generic;
using TSG.Game;
using UnityEngine;
using System.Linq;

public class TSG_ObjectsPoolsManager : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] List<TSG_ObjectsPool<TSG_Enemy>> enemyObjectsPools = new List<TSG_ObjectsPool<TSG_Enemy>>();
    [SerializeField] List<TSG_ObjectsPool<TSG_Player>> playerObjectsPools = new List<TSG_ObjectsPool<TSG_Player>>();
    [SerializeField] List<TSG_ObjectsPool<TSG_Bullet>> bulletObjectsPools = new List<TSG_ObjectsPool<TSG_Bullet>>();
    [SerializeField] List<TSG_ObjectsPool<TSG_Particle>> particleObjectsPools = new List<TSG_ObjectsPool<TSG_Particle>>();

    private void Start()
    {
        initObjectsPools();
    }

    public void OnDestroyCallback(TSG_GameEventData _gameEventData)
    {
        //GameObject _instance = _gameEventData.GameObjectValues[0];

        //for (int i = 0; i < bulletObjectsPools.Count; i++)
        //{
        //    GameObject _prefabInstance = bulletObjectsPools[i].Prefab?.gameObject;
        //    if(_prefabInstance.GetType() == _instance.GetType())
        //    {
        //        bulletObjectsPools[i].Release(_instance.GetComponent<MonoBehaviour>());
        //        break;
        //    }
        //}
    }

    private void wtf(GameObject _instance)
    {
        //if(_instance.TryGetComponent<TSG_Enemy>(out TSG_Enemy _enemy))
        //{
        //    enemyObjectsPools.Select(_ => _.Prefab.GetType() == _instance.GetType()).
        //}
        //else
        //{

        //}
    }

    private void initObjectsPools()
    {
        enemyObjectsPools.ForEach(_ => _.Init());
        playerObjectsPools.ForEach(_ => _.Init());
        bulletObjectsPools.ForEach(_ => _.Init());
        particleObjectsPools.ForEach(_ => _.Init());
    }
}
