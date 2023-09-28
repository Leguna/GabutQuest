using UnityEngine;
using UnityEngine.InputSystem;

namespace DamageSystem
{
    public class PlayerDamageController : MonoBehaviour
    {
        [SerializeField] private HealthController _healthController;
        [SerializeField] private WeaponController _weaponController;
        private PlayerDamageInputAction _playerDamageInputAction;

        private Animator _animator;

        private void Awake()
        {
            _healthController = new HealthController(100);
            _weaponController = new WeaponController(10);

            _healthController.SetListener(OnDamageTaken, OnHealTaken, OnDeath);
        }

        private void OnAttack(InputAction.CallbackContext obj)
        {
            
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