using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float playerSpeed = 1f;
        [SerializeField] private float jumpMultiplier = 22f;
        [SerializeField] private float gravityScale = 5f;
        [SerializeField] private float stoppingPoint = 10f;
        [SerializeField] private float returnToStoppingPointTime = 1;
        
        private Rigidbody _rigidbody;
        private GameMode _gameMode;
        private GroundChecker _groundChecker;
        private Rigidbody _mainCameraRigidbody;
        
        // Start is called before the first frame update
        void Start()
        {
            // One of the only reasons rigidbody works here is because all objects in the scene have a frictionless physics material
            _rigidbody = GetComponent<Rigidbody>();
            _gameMode = GetComponent<GameMode>();
            _groundChecker = GameObject.Find("Ground_Checker").GetComponent<GroundChecker>();
            _mainCameraRigidbody = GameObject.Find("Main_Camera").GetComponent<Rigidbody>();
        }
        
        // Update is called once per frame
        void Update()
        {
            HandleJump();
        }
        
        private void FixedUpdate()
        {
            MoveRight();
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
        }
        
        private void HandleJump()
        {
            // Used https://gamedevbeginner.com/how-to-jump-in-unity-with-or-without-physics/ for jumping mechanic
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        
        public void Jump()
        {
            if (CanJump())
            {
                _rigidbody.AddForce(Vector3.up * jumpMultiplier, ForceMode.Impulse);
            }
        }
        
        private bool CanJump()
        {
            return _groundChecker.GetIsTouchingGround();
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
