using SaveLoad;
using TwoDPlatformer;
using TwoDPlatformer.TwoDPlatformMovement.Scripts;
using UnityEngine;

namespace Actor
{
    public class PlayerSystem : MonoBehaviour
    {
        [SerializeField] private PlayerBaseData playerBaseData;
        private MovementController _playerMovement;
        private PlayerDamageController _playerDamageController;
        private MovementAnimationController _movementAnimationController;
        private PlayerCamera _playerCamera;

        public void Init(PlayerBaseData newPlayerBaseData)
        {
            playerBaseData = newPlayerBaseData;
            Init();
        }

        public void Init()
        {
            playerBaseData = ScriptableObject.CreateInstance<PlayerBaseData>();
            SaveLoadSystem.Load(playerBaseData);
            if (TryGetComponent(out _movementAnimationController))
                if (TryGetComponent(out _playerMovement))
                    _playerMovement.Init(_movementAnimationController);
            if (TryGetComponent(out _playerDamageController)) _playerDamageController.Init(playerBaseData);
            if (TryGetComponent(out _playerCamera)) _playerCamera.Init();
        }
    }
}