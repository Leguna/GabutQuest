using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DamageSystem
{
    public class PlayerDamageController : MonoBehaviour
    {
        [SerializeField] private HealthController healthController;
        [SerializeField] private WeaponController weaponController;
        private PlayerDamageInputAction _playerDamageInputAction;

        [HideInInspector] public bool canAttack;

        public void Init(PlayerBaseData playerBaseData)
        {
            healthController = new HealthController(100);
            healthController.SetListener(OnDamageTaken, OnHealTaken, OnDeath);
            weaponController.Init(playerBaseData.damageStats.attack);
            canAttack = true;
        }

        private void OnAttack(InputAction.CallbackContext obj)
        {
            if (!canAttack) return;
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
            Destroy(gameObject);
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