using UnityEngine;

namespace TwoDPlatformer.TwoDPlatformMovement.Scripts
{
    public class MovementAnimationController : MonoBehaviour
    {
        private MovementState _movementState;
        private Animator _animator;
        private static readonly int StateMovement = Animator.StringToHash("StateMovement");

        public MovementState MovementState
        {
            set
            {
                _movementState = value;
                UpdateAnimation();
            }
        }

        private void Start()
        {
            TryGetComponent(out _animator);
        }

        private void UpdateAnimation()
        {
            _animator.SetInteger(StateMovement, (int)_movementState);
        }
    }
}