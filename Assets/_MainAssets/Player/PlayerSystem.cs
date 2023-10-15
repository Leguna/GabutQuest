using System;
using DamageSystem;
using TwoDPlatformer.TwoDPlatformMovement.Scripts;
using UnityEngine;

namespace Player
{
    public class PlayerSystem : MonoBehaviour
    {
        private MovementController playerMovement;
        private PlayerDamageController playerDamageController;
        private MovementAnimationController movementAnimationController;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            TryGetComponent(out playerMovement);
            TryGetComponent(out playerDamageController);
            TryGetComponent(out movementAnimationController);

            playerMovement.Init(movementAnimationController);
            playerDamageController.Init();
        }
    }
}