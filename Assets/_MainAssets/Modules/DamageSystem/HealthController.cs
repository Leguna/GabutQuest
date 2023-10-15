using System;
using UnityEngine;

namespace DamageSystem
{
    [Serializable] public class HealthController : IHealthController
    {
        public int Health { get; set; }
        public int MaxHealth { get; private set; }

        private Action<int> _onDamageTaken;
        private Action<int> _onHealTaken;
        private Action _onDeath;

        public HealthController(int maxHealth)
        {
            MaxHealth = maxHealth;
            Health = maxHealth;
        }

        public void SetListener(Action<int> onDamageTaken, Action<int> onHealTaken, Action onDeath)
        {
            _onDamageTaken = onDamageTaken;
            _onHealTaken = onHealTaken;
            _onDeath = onDeath;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            _onDamageTaken?.Invoke(damage);
            if (Health <= 0) Die();
        }

        public void Die()
        {
            Health = 0;
            _onDeath?.Invoke();
        }

        public void Heal(int heal)
        {
            Health += heal;
            if (Health > MaxHealth) Health = MaxHealth;
            _onHealTaken?.Invoke(heal);
        }

        public void FullHeal()
        {
            Health = MaxHealth;
            _onHealTaken?.Invoke(MaxHealth);
        }
    }
}