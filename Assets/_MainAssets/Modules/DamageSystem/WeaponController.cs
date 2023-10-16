﻿using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DamageSystem
{
    [Serializable]
    public class WeaponController : MonoBehaviour, IWeaponController
    {
        [SerializeField] private GameObject weaponHandler;
        [SerializeField] private Animator animator;
        [SerializeField] private Collider2D weaponCollider;
        public int Damage { get; private set; }
        public float Delay { get; set; }
        public float LastAttackTime { get; private set; }
        private static readonly int AttackKey = Animator.StringToHash("Attack");

        public void Init(int damage)
        {
            TryGetComponent(out weaponCollider);
            TryGetComponent(out animator);
            Damage = damage;
        }

        public void FireAttack()
        {
            LastAttackTime = Time.time;
            weaponCollider.enabled = true;
            animator.SetTrigger(AttackKey);
        }

        private void FinishAnimation()
        {
            weaponCollider.enabled = false;
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