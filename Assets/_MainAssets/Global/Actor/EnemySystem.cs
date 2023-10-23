using Player;
using UnityEngine;

namespace DamageSystem
{
    public class EnemySystem : ObjectSystem
    {
        [SerializeField] private ActorBaseData actorBaseData;

        public override void Init()
        {
            base.Init();
            Health = actorBaseData.damageStats.currentHealth;
            MaxHealth = actorBaseData.damageStats.maxHealth;
            OnDeathEvent += OnDeath;
        }

        private void OnDeath()
        {
            Debug.Log("EnemySystem.OnDeath");
            Destroy(gameObject);
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            Debug.Log($"EnemySystem.TakeDamage: {damage}");
        }
    }
}