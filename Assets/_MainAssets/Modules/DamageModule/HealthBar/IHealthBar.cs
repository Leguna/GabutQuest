using System;
using UnityEngine;

namespace DamageModule.HealthBar
{
    public interface IHealthBar : IHealth
    {
        public event Action<int> OnHealTaken;
        public event Action<int> OnDamageTaken;
        public Color Color { get; }
    }
}