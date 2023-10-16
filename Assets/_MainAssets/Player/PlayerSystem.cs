using DamageSystem;
using TwoDPlatformer;
using TwoDPlatformer.TwoDPlatformMovement.Scripts;
using UnityEngine;

namespace Player
{
    public class PlayerSystem : MonoBehaviour
    {
        private MovementController _playerMovement;
        private PlayerDamageController _playerDamageController;
        private MovementAnimationController _movementAnimationController;
        private PlayerCamera _playerCamera;

        public void Init()
        {
            if (TryGetComponent(out _movementAnimationController))
                if (TryGetComponent(out _playerMovement))
                    _playerMovement.Init(_movementAnimationController);
            if (TryGetComponent(out _playerDamageController)) _playerDamageController.Init();
            if (TryGetComponent(out _playerCamera)) _playerCamera.Init();
        }
    }
}