using System;
using TSG.Model;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy, GameObject> onImpact = delegate { };
    public event Action<Enemy> onDie = delegate { };
    
    private EnemyModel model;
    public EnemyModel Model => model;
    
    public void Setup(EnemyModel model)
    {
        this.model = model;
        model.die += OnModelDie;
    }

    private void OnModelDie(EnemyModel obj)
    {
        onDie(this);
    }

    private void Update()
    {
        var pos = transform.position;
        pos.z -= model.Speed * Time.deltaTime;
        transform.position = pos;
    }

    public void TakeDamage(float damage)
    {
        model.TakeDamage(damage);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        onImpact.Invoke(this, other.gameObject);
    }
}