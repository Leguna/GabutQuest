using System;
using UnityEngine;

namespace DamageSystem
{
    public class HealthComponent
    {
        public event Action<float> OnHealthChanged;
        public event Action<float> OnHealthIncreased;
        public event Action<float> OnHealthDecreased;
        public Color Color;

        public float MaxHealth { get; }
        public float CurrentHealth { get; private set; }

        public HealthComponent(float currentHealth, float maxHealth, Color color)
        {
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;
            Color = color;
        }

        public void IncreaseHealth(float amount)
        {
            CurrentHealth += amount;
            OnHealthIncreased?.Invoke(amount);
            OnHealthChanged?.Invoke(CurrentHealth);
        }

        public void DecreaseHealth(float amount)
        {
            CurrentHealth -= amount;
            OnHealthDecreased?.Invoke(amount);
            OnHealthChanged?.Invoke(CurrentHealth);
        }
    }
}