using System;
using UnityEngine;

namespace DamageSystem
{
    [Serializable]
    public class WeaponController : MonoBehaviour, IWeaponController
    {
        public int Damage { get; private set; }
        public float Delay { get; set; }
        public float LastAttackTime { get; private set; }

        public WeaponController(int damage)
        {
            Damage = damage;
        }

        public void Attack(IDamageable target)
        {
            if (Time.time - LastAttackTime < Delay) return;
            target.TakeDamage(Damage);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable damageable))
            {
                Attack(damageable);
            }
        }
    }
}