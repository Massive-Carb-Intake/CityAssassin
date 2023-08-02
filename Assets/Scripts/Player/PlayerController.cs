using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        // [Header("Player")]
        // [Tooltip("Move speed of the character in m/s")]
        // public float MoveSpeed = 2.0f;
        //
        // [Tooltip("Sprint speed of the character in m/s")]
        // public float SprintSpeed = 5.335f;
        //
        // [Tooltip("How fast the character turns to face movement direction")]
        // [Range(0.0f, 0.3f)]
        // public float RotationSmoothTime = 0.12f;
        //
        // [Tooltip("Acceleration and deceleration")]
        // public float SpeedChangeRate = 10.0f;
        //
        // public AudioClip LandingAudioClip;
        // public AudioClip[] FootstepAudioClips;
        // [Range(0, 1)] public float FootstepAudioVolume = 0.5f;
        //
        // [Space(10)]
        // [Tooltip("The height the player can jump")]
        // public float JumpHeight = 1.2f;
        //
        // [Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
        // public float Gravity = -15.0f;
        //
        // [Space(10)]
        // [Tooltip("Time required to pass before being able to jump again. Set to 0f to instantly jump again")]
        // public float JumpTimeout = 0.50f;
        //
        // [Tooltip("Time required to pass before entering the fall state. Useful for walking down stairs")]
        // public float FallTimeout = 0.15f;
        //
        // [Header("Player Grounded")]
        // [Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
        // public bool Grounded = true;
        //
        // [Tooltip("Useful for rough ground")]
        // public float GroundedOffset = -0.14f;
        //
        // [Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
        // public float GroundedRadius = 0.28f;
        //
        // [Tooltip("What layers the character uses as ground")]
        // public LayerMask GroundLayers;
        //
        // // cinemachine
        // private float _cinemachineTargetYaw;
        // private float _cinemachineTargetPitch;
        //
        // // player
        // private float _speed;
        // private float _animationBlend;
        // private float _targetRotation = 0.0f;
        // private float _rotationVelocity;
        // private float _verticalVelocity;
        // private float _terminalVelocity = 53.0f;
        //
        // // timeout deltatime
        // private float _jumpTimeoutDelta;
        // private float _fallTimeoutDelta;
        //
        // // animation IDs
        // private int _animIDSpeed;
        // private int _animIDGrounded;
        // private int _animIDJump;
        // private int _animIDFreeFall;
        // private int _animIDMotionSpeed;
        //
        // private Animator _animator;
        // private CharacterController _controller;
        // private GameObject _mainCamera;
        //
        // private const float _threshold = 0.01f;
        //
        // private bool _hasAnimator;
        // private Rigidbody _mainCameraRigidbody;
        //
        // private void Start()
        // {
        //     
        //     _hasAnimator = TryGetComponent(out _animator);
        //     _controller = GetComponent<CharacterController>();
        //     _mainCamera = GameObject.Find("Main_Camera");
        //     _mainCameraRigidbody = GameObject.Find("Main_Camera").GetComponent<Rigidbody>();
        //
        //     AssignAnimationIDs();
        //
        //     // reset our timeouts on start
        //     _jumpTimeoutDelta = JumpTimeout;
        //     _fallTimeoutDelta = FallTimeout;
        // }
        //
        // private void Update()
        // {
        //     _hasAnimator = TryGetComponent(out _animator);
        //
        //     JumpAndGravity();
        //     GroundedCheck();
        //     Move();
        // }
        //
        // private void AssignAnimationIDs()
        // {
        //     _animIDSpeed = Animator.StringToHash("Speed");
        //     _animIDGrounded = Animator.StringToHash("Grounded");
        //     _animIDJump = Animator.StringToHash("Jump");
        //     _animIDFreeFall = Animator.StringToHash("FreeFall");
        //     _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
        // }
        //
        // private void GroundedCheck()
        // {
        //     // set sphere position, with offset
        //     var position = transform.position;
        //     Vector3 spherePosition = new Vector3(position.x, position.y - GroundedOffset,
        //         position.z);
        //     Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers,
        //         QueryTriggerInteraction.Ignore);
        //
        //     // update animator if using character
        //     if (_hasAnimator)
        //     {
        //         _animator.SetBool(_animIDGrounded, Grounded);
        //     }
        // }
        //
        // private void Move()
        // {
        //     // set target speed based on move speed, sprint speed and if sprint is pressed
        //     float targetSpeed = _input.sprint ? SprintSpeed : MoveSpeed;
        //
        //     // a simplistic acceleration and deceleration designed to be easy to remove, replace, or iterate upon
        //
        //     // note: Vector2's == operator uses approximation so is not floating point error prone, and is cheaper than magnitude
        //     // if there is no input, set the target speed to 0
        //     if (_input.move == Vector2.zero) targetSpeed = 0.0f;
        //
        //     // a reference to the players current horizontal velocity
        //     float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;
        //
        //     float speedOffset = 0.1f;
        //     float inputMagnitude = _input.analogMovement ? _input.move.magnitude : 1f;
        //
        //     // accelerate or decelerate to target speed
        //     if (currentHorizontalSpeed < targetSpeed - speedOffset ||
        //         currentHorizontalSpeed > targetSpeed + speedOffset)
        //     {
        //         // creates curved result rather than a linear one giving a more organic speed change
        //         // note T in Lerp is clamped, so we don't need to clamp our speed
        //         _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude,
        //             Time.deltaTime * SpeedChangeRate);
        //
        //         // round speed to 3 decimal places
        //         _speed = Mathf.Round(_speed * 1000f) / 1000f;
        //     }
        //     else
        //     {
        //         _speed = targetSpeed;
        //     }
        //
        //     _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * SpeedChangeRate);
        //     if (_animationBlend < 0.01f) _animationBlend = 0f;
        //
        //     // normalise input direction
        //     Vector3 inputDirection = new Vector3(_input.move.x, 0.0f, _input.move.y).normalized;
        //
        //     // note: Vector2's != operator uses approximation so is not floating point error prone, and is cheaper than magnitude
        //     // if there is a move input rotate player when the player is moving
        //     if (_input.move != Vector2.zero)
        //     {
        //         _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg +
        //                           _mainCamera.transform.eulerAngles.y;
        //         float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
        //             RotationSmoothTime);
        //
        //         // rotate to face input direction relative to camera position
        //         transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        //     }
        //
        //
        //     Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;
        //
        //     // move the player
        //     _controller.Move(targetDirection.normalized * (_speed * Time.deltaTime) +
        //                      new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);
        //
        //     // update animator if using character
        //     if (_hasAnimator)
        //     {
        //         _animator.SetFloat(_animIDSpeed, _animationBlend);
        //         _animator.SetFloat(_animIDMotionSpeed, inputMagnitude);
        //     }
        // }
        //
        // private void JumpAndGravity()
        // {
        //     if (Grounded)
        //     {
        //         // reset the fall timeout timer
        //         _fallTimeoutDelta = FallTimeout;
        //
        //         // update animator if using character
        //         if (_hasAnimator)
        //         {
        //             _animator.SetBool(_animIDJump, false);
        //             _animator.SetBool(_animIDFreeFall, false);
        //         }
        //
        //         // stop our velocity dropping infinitely when grounded
        //         if (_verticalVelocity < 0.0f)
        //         {
        //             _verticalVelocity = -2f;
        //         }
        //
        //         // Jump
        //         if (_input.jump && _jumpTimeoutDelta <= 0.0f)
        //         {
        //             // the square root of H * -2 * G = how much velocity needed to reach desired height
        //             _verticalVelocity = Mathf.Sqrt(JumpHeight * -2f * Gravity);
        //
        //             // update animator if using character
        //             if (_hasAnimator)
        //             {
        //                 _animator.SetBool(_animIDJump, true);
        //             }
        //         }
        //
        //         // jump timeout
        //         if (_jumpTimeoutDelta >= 0.0f)
        //         {
        //             _jumpTimeoutDelta -= Time.deltaTime;
        //         }
        //     }
        //     else
        //     {
        //         // reset the jump timeout timer
        //         _jumpTimeoutDelta = JumpTimeout;
        //
        //         // fall timeout
        //         if (_fallTimeoutDelta >= 0.0f)
        //         {
        //             _fallTimeoutDelta -= Time.deltaTime;
        //         }
        //         else
        //         {
        //             // update animator if using character
        //             if (_hasAnimator)
        //             {
        //                 _animator.SetBool(_animIDFreeFall, true);
        //             }
        //         }
        //
        //         // if we are not grounded, do not jump
        //         _input.jump = false;
        //     }
        //
        //     // apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
        //     if (_verticalVelocity < _terminalVelocity)
        //     {
        //         _verticalVelocity += Gravity * Time.deltaTime;
        //     }
        // }
        //
        // private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
        // {
        //     if (lfAngle < -360f) lfAngle += 360f;
        //     if (lfAngle > 360f) lfAngle -= 360f;
        //     return Mathf.Clamp(lfAngle, lfMin, lfMax);
        // }
        //
        // private void OnDrawGizmosSelected()
        // {
        //     Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
        //     Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);
        //
        //     if (Grounded) Gizmos.color = transparentGreen;
        //     else Gizmos.color = transparentRed;
        //
        //     // when selected, draw a gizmo in the position of, and matching radius of, the grounded collider
        //     Gizmos.DrawSphere(
        //         new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z),
        //         GroundedRadius);
        // }
        //
        // private void OnFootstep(AnimationEvent animationEvent)
        // {
        //     if (animationEvent.animatorClipInfo.weight > 0.5f)
        //     {
        //         if (FootstepAudioClips.Length > 0)
        //         {
        //             var index = Random.Range(0, FootstepAudioClips.Length);
        //             AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.TransformPoint(_controller.center), FootstepAudioVolume);
        //         }
        //     }
        // }
        //
        // private void OnLand(AnimationEvent animationEvent)
        // {
        //     if (animationEvent.animatorClipInfo.weight > 0.5f)
        //     {
        //         AudioSource.PlayClipAtPoint(LandingAudioClip, transform.TransformPoint(_controller.center), FootstepAudioVolume);
        //     }
        // }
        
        [SerializeField] private float playerSpeed = 1f;
        [SerializeField] private float jumpMultiplier = 22f;
        [SerializeField] private float gravityScale = 5f;
        [SerializeField] private float stoppingPoint = 10f;
        [SerializeField] private float returnToStoppingPointTime = 1;
        
        private bool _grounded = true;
        [SerializeField] private LayerMask groundLayers;
        
        private Rigidbody _rigidbody;
        private GameMode _gameMode;
        private GroundChecker _groundChecker;
        private Rigidbody _mainCameraRigidbody;
        private Animator _animator;
        private int _animIDSpeed;
        private int _animIDGrounded;
        private int _animIDJump;
        private int _animIDFreeFall;
        private int _animIDMotionSpeed;
        
        // Start is called before the first frame update
        void Start()
        {
            // One of the only reasons rigidbody works here is because all objects in the scene have a frictionless physics material
            _rigidbody = GetComponent<Rigidbody>();
            _gameMode = GetComponent<GameMode>();
            _animator = GetComponent<Animator>();
            _groundChecker = GameObject.Find("Ground_Checker").GetComponent<GroundChecker>();
            _mainCameraRigidbody = GameObject.Find("Main_Camera").GetComponent<Rigidbody>();
            
            AssignAnimationIDs();
        }
        
        private void AssignAnimationIDs()
        {
            _animIDSpeed = Animator.StringToHash("Speed");
            _animIDGrounded = Animator.StringToHash("Grounded");
            _animIDJump = Animator.StringToHash("Jump");
            _animIDFreeFall = Animator.StringToHash("FreeFall");
            _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
        }
        
        // Update is called once per frame
        void Update()
        {
            HandleJump();
        }
        
        private void FixedUpdate()
        {
            // MoveRight();
            MoveCameraRight();
            ApplyIncreasedGravity();
        }
        
        private void MoveCameraRight()
        {
            _mainCameraRigidbody.velocity = new Vector3(_gameMode.GetCurrentWorldSpeed(), 0, 0);
        }
        
        private void ApplyIncreasedGravity()
        {
            _rigidbody.AddForce(Physics.gravity * ((gravityScale - 1) * _rigidbody.mass));
        }
        
        private void MoveRight()
        {
            // The entire thing has to be in clamping because clamping has become the
            // single-biggest flaw in player movement
            if (_rigidbody.position.x >= stoppingPoint + _mainCameraRigidbody.transform.position.x && _groundChecker.GetIsTouchingGround())
            {
                ClampPosition();
            }
            else
            {
                Vector3 velocity = _rigidbody.velocity;
                velocity = new Vector3(playerSpeed + _gameMode.GetCurrentWorldSpeed(), velocity.y, velocity.z);
                _rigidbody.velocity = velocity;
            }
            
            _animator.SetFloat(_animIDSpeed, _rigidbody.velocity.x);
            _animator.SetFloat(_animIDMotionSpeed, _rigidbody.velocity.x);
        }
        
        private void HandleJump()
        {
            // Used https://gamedevbeginner.com/how-to-jump-in-unity-with-or-without-physics/ for jumping mechanic
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            else
            {
                _animator.SetBool(_animIDFreeFall, true);
            }
        }
        
        public void Jump()
        {
            if (_grounded)
            {
        
                _animator.SetBool(_animIDJump, false);
                _animator.SetBool(_animIDFreeFall, false);
                
                _rigidbody.AddForce(Vector3.up * jumpMultiplier, ForceMode.Impulse);
                _animator.SetBool(_animIDJump, true);
            }
        }
        
        private void CanJump()
        {
            // set sphere position, with offset
            Vector3 position = transform.position;
            Vector3 spherePosition = new Vector3(position.x, position.y,
                position.z);
            _grounded = Physics.CheckSphere(spherePosition, 0.28f, groundLayers,
                QueryTriggerInteraction.Ignore);
        
            // update animator if using character
            _animator.SetBool(_animIDGrounded, _grounded);
        }
        
        /*
         * This single mechanic took me more time to get right than most of the other stuff combined
         * And it still doesn't work perfectly
         * It wobbles now lol
         */
        private void ClampPosition()
        {
            Vector3 velocity = _rigidbody.velocity;
            velocity = new Vector3(-((_rigidbody.position.x - (stoppingPoint + _mainCameraRigidbody.transform.position.x)) / returnToStoppingPointTime + playerSpeed), velocity.y, velocity.z);
            _rigidbody.velocity = velocity;
        }
        
        // private CharacterController _controller;
        // private Vector3 _playerVelocity;
        // private bool _groundedPlayer;
        // [SerializeField] private float playerSpeed = 1.0f;
        // [SerializeField] private float jumpHeight = 3.0f;
        // [SerializeField] private float gravityValue = -9.81f;
        //
        // private GameMode _gameMode;
        // private Rigidbody _mainCameraRigidbody;
        //
        // private void Start()
        // {
        //     _controller = gameObject.GetComponent<CharacterController>();
        //     _gameMode = GetComponent<GameMode>();
        //     _mainCameraRigidbody = GameObject.Find("Main_Camera").GetComponent<Rigidbody>();
        // }
        //
        // private void HandleJump()
        // {
        //     // Changes the height position of the player..
        //     if (Input.GetKeyDown(KeyCode.Space) && _groundedPlayer)
        //     {
        //         _playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        //     }
        //
        //     _playerVelocity.y += gravityValue * Time.deltaTime;
        //     _controller.Move(_playerVelocity * Time.deltaTime);
        // }
        //
        // void Update()
        // {
        //     MovePlayer();
        //     MoveCameraRight();
        //     HandleJump();
        // }
        //
        // private void MovePlayer()
        // {
        //     _groundedPlayer = _controller.isGrounded;
        //     if (_groundedPlayer && _playerVelocity.y < 0)
        //     {
        //         _playerVelocity.y = 0f;
        //     }
        //
        //     Vector3 move = new Vector3(_gameMode.GetCurrentWorldSpeed(), 0, 0);
        //     _controller.Move(move * Time.deltaTime);
        //
        //     if (move != Vector3.zero)
        //     {
        //         gameObject.transform.forward = move;
        //     }
        //
        //     
        // }
        //
        // private void MoveCameraRight()
        // {
        //     _mainCameraRigidbody.velocity = new Vector3(_gameMode.GetCurrentWorldSpeed(), 0, 0);
        // }
    }
}
