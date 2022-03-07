﻿using System;
using TSG.Utils;
using UnityEngine;

namespace TSG.Model
{
    public class EnemyModel : IModel
    {
        public event Action<EnemyModel> die = delegate { };
        public event Action<EnemyModel, float> damageTaken = delegate { };
        
        public int MaxHp { get; }
        public float Speed { get; }
        public float Damage { get;  }
        public int Hp { get; private set; }
        
        public EnemyModel(EnemyConfig config)
        {
            MaxHp = config.Hitpoints;
            Hp = config.Hitpoints;
            Speed = config.Speed;
            Damage = config.Damage;
        }
        
        public bool IsDead()
        {
            return Hp == 0;
        }

        public void TakeDamage(float damage)
        {
            if (IsDead())
            {
                return;
            }
            Hp = (int) Mathf.Max(0, Hp - damage);
            damageTaken(this, damage);
            if (!IsDead())
            {
                return;
            }
            die(this);
        }
    }
}
