using System;
using TSG.Model;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy, GameObject> onImpact = delegate { };
    
    private EnemyModel model;
    public EnemyModel Model => model;
    
    public void Setup(EnemyModel model)
    {
        this.model = model;
    }

    private void Update()
    {
        var pos = transform.position;
        pos.z -= model.Speed * Time.deltaTime;
        transform.position = pos;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        onImpact.Invoke(this, other.gameObject);
    }
}