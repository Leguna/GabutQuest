using System;
using UnityEngine;

namespace DamageSystem
{
    public class ObjectController : MonoBehaviour, IDamageable, IHealth
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public Action OnDeathEvent { get; set; }

        public virtual void Init(int maxHealth)
        {
            MaxHealth = maxHealth;
            Health = maxHealth;
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