using UnityEngine;
using UnityEngine.InputSystem;

namespace DamageSystem
{
    public class PlayerDamageController : MonoBehaviour
    {
        [SerializeField] private HealthController healthController;
        [SerializeField] private WeaponController weaponController;
        private PlayerDamageInputAction _playerDamageInputAction;

        private Animator _animator;

        private void Awake()
        {
            healthController = new HealthController(100);
            healthController.SetListener(OnDamageTaken, OnHealTaken, OnDeath);
            TryGetComponent(out _animator);
        }

        private void OnAttack(InputAction.CallbackContext obj)
        {
            weaponController.FireAttack();
        }

        private void OnDamageTaken(int obj)
        {
            Debug.Log($"Player took {obj} damage");
        }

        private void OnHealTaken(int obj)
        {
            Debug.Log($"Player healed {obj} health");
        }

        private void OnDeath()
        {
            Debug.Log("Player died");
        }

        private void OnEnable()
        {
            _playerDamageInputAction = new PlayerDamageInputAction();
            _playerDamageInputAction.Enable();
            _playerDamageInputAction.Player.Attack.performed += OnAttack;
        }

        private void OnDisable()
        {
            _playerDamageInputAction.Disable();
            _playerDamageInputAction.Player.Attack.performed -= OnAttack;
        }
    }
}