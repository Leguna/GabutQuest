using UnityEngine;

namespace TwoDPlatformMovement.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementController : MonoBehaviour
    {
        public enum MovementState
        {
            Idle,
            Walking,
            Running,
            Dashing,
            Jumping,
            Falling,
            Landing
        }

        // Inspector fields
        [SerializeField] private float _walkSpeed = 5f;
        [SerializeField] private float _runSpeed = 10f;
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private float _dashForce = 10f;
        [SerializeField] private float _dashDuration = 0.2f;
        [SerializeField] private float _jumpMoveSpeedMultiplier = 1f;

        // Input
        private readonly MovementInput _movementInput = new();
        private float _horizontalInput;
        private bool _isDashing;
        private bool _isFacingRight = true;
        private bool _isRunning;

        // Private fields
        private MovementState _movementState;

        // Components
        private Rigidbody2D _rigidbody2D;
        private readonly bool isOverrideCanMove = false;

        private bool CanJump => _movementState is MovementState.Idle or MovementState.Walking
            or MovementState.Running;

        private bool CanDash => _movementState is MovementState.Idle or MovementState.Walking or MovementState.Running;

        private bool CanMove => _movementState is MovementState.Jumping or MovementState.Falling
            or MovementState.Landing or MovementState.Idle or MovementState.Running or MovementState.Walking;

        public void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _movementInput.Init();
            _movementInput.OnMoveHorizontal += Walk;
            _movementInput.OnRun += Run;
            _movementInput.OnJump += Jump;
            _movementInput.OnDash += () => Dash(_dashForce);
        }

        public void FixedUpdate()
        {
            Move();
            UpdateState();
        }

        private void UpdateState()
        {
            if (_movementState == MovementState.Dashing) return;

            if (IsLanding())
            {
                if (_movementState is MovementState.Landing or MovementState.Walking or MovementState.Running
                    or MovementState.Idle)
                {
                }
                else
                {
                    _movementState = MovementState.Landing;
                    return;
                }
            }

            if (_rigidbody2D.velocity.y < 0f && !IsLanding() && _movementState != MovementState.Falling)
            {
                _movementState = MovementState.Falling;
                return;
            }

            if (_movementState == MovementState.Jumping)
                return;

            if (_horizontalInput != 0 && IsLanding())
            {
                _movementState = _isRunning ? MovementState.Running : MovementState.Walking;
                return;
            }

            if (_movementState != MovementState.Idle && IsLanding())
            {
                _movementState = MovementState.Idle;
            }
        }

        private bool IsLanding()
        {
            var boxCastSize = new Vector2(0.5f, 0.5f);
            var distance = 0.5f;
            var hit = Physics2D.BoxCast(transform.position, boxCastSize, 0f, Vector2.down, distance,
                LayerMask.GetMask("Ground"));
            // Draw box cast
            Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);
            return hit.collider != null && _rigidbody2D.velocity.y <= 0.1f && _rigidbody2D.velocity.y >= -0.1;
        }

        private void Move()
        {
            if (!isOverrideCanMove) return;
            if (!CanMove) return;

            var moveSpeed = _isRunning ? _runSpeed : _walkSpeed;
            if (_movementState == MovementState.Jumping) moveSpeed *= _jumpMoveSpeedMultiplier;

            var moveVelocity =
                new Vector2(_horizontalInput * moveSpeed, _rigidbody2D.velocity.y);


            // Facing
            if ((_horizontalInput > 0f && !_isFacingRight) || (_horizontalInput < 0f && _isFacingRight)) Flip();

            _rigidbody2D.velocity = moveVelocity;
        }

        private void Flip()
        {
            _isFacingRight = !_isFacingRight;
            transform.localScale = new Vector3(_isFacingRight ? 1 : -1, 1, 1);
        }

        private void Walk(float direction)
        {
            _horizontalInput = direction;
            Move();
        }

        private void Run(bool isRunning)
        {
            _isRunning = isRunning;
            Move();
        }

        private void Jump()
        {
            if (!isOverrideCanMove) return;
            if (!CanJump)
                return;

            _rigidbody2D.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
            _movementState = MovementState.Jumping;
        }

        private void Dash(float dashForce)
        {
            if (!CanDash)
                return;

            _rigidbody2D.AddForce(new Vector2(_isFacingRight ? dashForce : -dashForce, 0f), ForceMode2D.Impulse);
            _movementState = MovementState.Dashing;
            Invoke(nameof(StopMovement), _dashDuration);
        }

        private void StopMovement()
        {
            // _rigidbody2D.velocity = Vector2.zero;
            _movementState = MovementState.Idle;
        }

        public MovementState GetMovementState()
        {
            return _movementState;
        }
    }
}