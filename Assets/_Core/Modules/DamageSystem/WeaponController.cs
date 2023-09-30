using System;
using UnityEngine;

namespace DamageSystem
{
    [Serializable]
    public class WeaponController : MonoBehaviour, IWeaponController
    {
        [SerializeField] private GameObject weaponHandler;
        [SerializeField] private Animator animator;
        private Collider2D _collider2D;
        public int Damage { get; private set; }
        public float Delay { get; set; }
        public float LastAttackTime { get; private set; }
        private static readonly int AttackKey = Animator.StringToHash("Attack");

        private void Start()
        {
            TryGetComponent(out _collider2D);
            TryGetComponent(out animator);
            Init(10);
        }

        public void Init(int damage)
        {
            Damage = damage;
        }

        public void FireAttack()
        {
            LastAttackTime = Time.time;
            _collider2D.enabled = true;
            animator.SetTrigger(AttackKey);
        }

        private void FinishAnimation()
        {
            _collider2D.enabled = false;
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
            Debug.Log( $"OnTriggerEnter2D: {other.gameObject.name}");
            Attack(damageable);
        }
    }
}