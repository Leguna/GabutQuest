using UnityEngine;

namespace DamageSystem
{
    public class ObjectController : MonoBehaviour, IDamageable, IHealth
    {
        private void Start()
        {
            Init(50);
        }

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
            Destroy(gameObject);
        }

        public int Health { get; set; }
        public int MaxHealth { get; }
    }
}