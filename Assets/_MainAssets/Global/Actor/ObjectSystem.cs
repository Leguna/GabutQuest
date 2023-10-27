using System;
using DamageModule;
using UnityEngine;

namespace Actor
{
    public class ObjectSystem : MonoBehaviour, IDamageable, IHealth
    {
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
        protected Action OnDeathEvent { get; set; }

        public virtual void Init()
        {
            CurrentHealth = 1;
            MaxHealth = 1;
        }

        public virtual void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0) Die();
        }

        public virtual void Die()
        {
            OnDeathEvent?.Invoke();
        }
    }
}