using System;
using UnityEngine;

namespace DamageSystem
{
    public class ObjectSystem : MonoBehaviour, IDamageable, IHealth
    {
        public int Health { get; set; }
        public int MaxHealth { get; protected set; }
        protected Action OnDeathEvent { get; set; }

        public virtual void Init()
        {
            Health = 1;
            MaxHealth = 1;
        }

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0) Die();
        }

        public virtual void Die()
        {
            OnDeathEvent?.Invoke();
        }
    }
}