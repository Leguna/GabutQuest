using UnityEngine;

namespace TwoDPlatformer.TwoDPlatformMovement.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementController : MonoBehaviour
    {
        // Inspector fields
        [SerializeField] private float walkSpeed = 5f;
        [SerializeField] private float runSpeed = 10f;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private float dashForce = 10f;
        [SerializeField] private float dashDuration = 0.2f;
        [SerializeField] private float jumpMoveSpeedMultiplier = 1f;

        [SerializeField] private ParticleSystem walkParticle;

        // Animation
        [SerializeField] private MovementAnimationController movementAnimationController;

        // Input
        private readonly MovementInput _movementInput = new();
        private float _horizontalInput;
        private bool _isDashing;
        private bool _isFacingRight = true;
        private bool _isRunning;

        // Private fields
        private MovementState _movementState = MovementState.Idle;

        private MovementState MovementState
        {
            get => _movementState;
            set
            {
                _movementState = value;
                UpdateAnimation();
            }
        }

        // Components

        private Rigidbody2D _rigidbody2D;

        public bool isOverrideCanMove = true;

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
            _movementInput.OnDash += Dash;
        }

        private void UpdateAnimation()
        {
            movementAnimationController.MovementState = _movementState;
        }

        public void FixedUpdate()
        {
            Move();
            UpdateState();
        }

        private void UpdateState()
        {
            if (_movementState == MovementState.Dashing) return;

            if (IsGrounded())
            {
                if (_movementState is MovementState.Landing or MovementState.Walking or MovementState.Running
                    or MovementState.Idle)
                {
                }
                else
                {
                    MovementState = MovementState.Landing;
                    return;
                }
            }

            if (_rigidbody2D.velocity.y < 0f && !IsGrounded() && _movementState != MovementState.Falling)
            {
                MovementState = MovementState.Falling;
                return;
            }

            if (_movementState == MovementState.Jumping)
                return;

            if (_horizontalInput != 0 && IsGrounded())
            {
                MovementState = _isRunning ? MovementState.Running : MovementState.Walking;
                return;
            }

            if (_movementState != MovementState.Idle && IsGrounded())
            {
                MovementState = MovementState.Idle;
            }
        }

        private bool IsGrounded()
        {
            var boxCastSize = new Vector2(0.5f, 0.5f);
            var distance = 0.5f;
            var position = transform.position;
            var hit = Physics2D.BoxCast(position, boxCastSize, 0f, Vector2.down, distance,
                LayerMask.GetMask("Ground"));
            // Raycast for getting the ground layer
            Debug.DrawRay(position, Vector2.down * distance, Color.red);
            var velocity = _rigidbody2D.velocity;
            return hit.collider && velocity.y <= 0.1f && velocity.y >= -0.1;
        }

        private void Move()
        {
            if (!isOverrideCanMove) return;
            if (!CanMove) return;

            // Particle if particle is exist
            if (IsGrounded() && _horizontalInput != 0) walkParticle.Play();

            // Movement
            var moveSpeed = _isRunning ? runSpeed : walkSpeed;
            if (_movementState == MovementState.Jumping) moveSpeed *= jumpMoveSpeedMultiplier;

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

            _rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            MovementState = MovementState.Jumping;
        }

        private void Dash()
        {
            if (!CanDash)
                return;

            _rigidbody2D.AddForce(new Vector2(_isFacingRight ? dashForce : -dashForce, 0f), ForceMode2D.Impulse);
            MovementState = MovementState.Dashing;
            Invoke(nameof(StopMovement), dashDuration);
        }

        private void StopMovement()
        {
            MovementState = MovementState.Idle;
        }
    }
}