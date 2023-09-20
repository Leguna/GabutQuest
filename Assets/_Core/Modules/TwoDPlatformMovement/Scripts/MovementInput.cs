using UnityEngine.Events;

namespace TwoDPlatformMovement.Scripts
{
    public class MovementInput
    {
        private MovementInputAction _movementInputAction;
        public UnityAction OnDash;
        public UnityAction OnJump;
        public UnityAction<float> OnMoveHorizontal;
        public UnityAction<bool> OnRun;

        public void Init()
        {
            _movementInputAction = new MovementInputAction();
            _movementInputAction.Enable();
            _movementInputAction.Player.MoveHorizontal.performed +=
                ctx => OnMoveHorizontal?.Invoke(ctx.ReadValue<float>());
            _movementInputAction.Player.MoveHorizontal.canceled += _ => OnMoveHorizontal?.Invoke(0f);
            _movementInputAction.Player.Run.performed += ctx => OnRun?.Invoke(ctx.ReadValueAsButton());
            _movementInputAction.Player.Jump.performed += _ => OnJump?.Invoke();
            _movementInputAction.Player.Dash.performed += _ => OnDash?.Invoke();
        }

        public void Enable()
        {
            _movementInputAction.Enable();
        }

        public void Disable()
        {
            _movementInputAction.Disable();
        }
    }
}