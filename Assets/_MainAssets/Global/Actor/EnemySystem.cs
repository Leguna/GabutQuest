using DamageModule;
using UnityEngine;

namespace Actor
{
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField] private ActorBaseData actorBaseData;
        private HealthController healthController;
        private DamageSystem damageSystem;

        public void Init(DamageSystem newDamageSystem)
        {
            damageSystem = newDamageSystem;
            healthController = gameObject.AddComponent<HealthController>();
            healthController.Init(actorBaseData.damageStats.maxHealth, Color.red);
            healthController.SetListener(TakeDamage, OnHealTaken, Die);
            damageSystem.ShowHealthBar(healthController, transform);
        }

        private void OnHealTaken(int healTakenValue)
        {
            healthController.Heal(healTakenValue);
        }

        public void TakeDamage(int damage)
        {
            damageSystem.ShowDamagePopup(damage, transform.position, Vector2.up);
            Debug.Log($"EnemySystem.TakeDamage: {damage}");
        }

        public void Die()
        {
            Debug.Log("EnemySystem.OnDeath");
            gameObject.SetActive(false);
        }
    }
}