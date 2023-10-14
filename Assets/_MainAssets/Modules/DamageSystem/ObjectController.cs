using System;
using UnityEngine;

namespace DamageSystem
{
    public class ObjectController : MonoBehaviour, IDamageable, IHealth
    {
        public int Health { get; set; }
        public int MaxHealth { get; }
        public Action OnDeathEvent { get; set; }

        public void Init(int maxHealth)
        {
            Health = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0) OnDeath();
        }


        public void OnDeath()
        {
            OnDeathEvent?.Invoke();
        }
    }
}