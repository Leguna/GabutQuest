using System;
using DamageModule;
using UnityEngine;

namespace Actor
{
    [Serializable]
    public class WeaponController : MonoBehaviour, IWeaponController
    {
        [SerializeField] private GameObject weaponHandler;
        [SerializeField] private Animator animator;
        [SerializeField] private Collider2D weaponCollider;
        private static readonly int Attacking = Animator.StringToHash("Attacking");
        public int Damage { get; private set; }
        public float Delay { get; set; }
        public float LastAttackTime { get; private set; }

        public void Init(int damage)
        {
            TryGetComponent(out weaponCollider);
            TryGetComponent(out animator);
            Damage = damage;
        }

        public void FireAttack()
        {
            LastAttackTime = Time.time;
            animator.SetTrigger(Attacking);
        }
        
        public void ActivateWeapon()
        {
            weaponCollider.enabled = true;
        }

        public void DeactivateWeapon()
        {
            weaponCollider.enabled = false;
        }

        private void FinishAnimation()
        {
            animator.ResetTrigger(Attacking);
        }


        public void Attack(IDamageable target)
        {
            if (Time.time - LastAttackTime < Delay) return;
            target.TakeDamage(Damage);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject == weaponHandler) return;
            if (!other.TryGetComponent(out IDamageable damageable)) return;
            Attack(damageable);
        }
    }
}