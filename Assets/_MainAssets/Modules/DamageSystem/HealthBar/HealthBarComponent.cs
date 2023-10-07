using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DamageSystem.HealthBar
{
    public class HealthBarComponent : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        [SerializeField] private float changeSpeed = 0.5f;

        private float _currentHealth;
        private float _maxHealth;

        public void Init(HealthComponent healthComponent, Transform newTargetTransform, Vector3 offset = default)
        {
            transform.SetParent(newTargetTransform);
            GetComponent<Canvas>().worldCamera = Camera.main;
            transform.localPosition = offset;

            _currentHealth = healthComponent.CurrentHealth;
            _maxHealth = healthComponent.MaxHealth;
            healthBar.color = healthComponent.Color;
            SetListener(healthComponent);
            UpdateBar(_currentHealth);
        }

        private void SetListener(HealthComponent healthComponent)
        {
            healthComponent.OnHealthChanged += UpdateBar;
            healthComponent.OnHealthDecreased += DecreaseHealth;
            healthComponent.OnHealthIncreased += IncreaseHealth;
        }

        private void UpdateBar(float amount)
        {
            var fillAmount = _currentHealth / _maxHealth;
            healthBar.DOFillAmount(fillAmount, changeSpeed);
        }

        private void DecreaseHealth(float amount)
        {
            _currentHealth -= amount;
            UpdateBar(_currentHealth);
        }

        private void IncreaseHealth(float amount)
        {
            _currentHealth += amount;
            UpdateBar(_currentHealth);
        }
    }
}