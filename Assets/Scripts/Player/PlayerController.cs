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
        private GroundChecker _groundChecker;

        // Start is called before the first frame update
        void Start()
        {
            // One of the only reasons rigidbody works here is because all objects in the scene have a frictionless physics material
            _rigidbody = GetComponent<Rigidbody>();
            _groundChecker = GameObject.Find("Ground_Checker").GetComponent<GroundChecker>();
        }

        // Update is called once per frame
        void Update()
        {
            HandleJump();
        }

        private void FixedUpdate()
        {
            MoveRight();
            ApplyIncreasedGravity();
        }

        private void ApplyIncreasedGravity()
        {
            _rigidbody.AddForce(Physics.gravity * ((gravityScale - 1) * _rigidbody.mass));
        }

        private void MoveRight()
        {
            // The entire thing has to be in clamping because clamping has become the
            // single-biggest flaw in player movement
            ClampPosition();
        }

        private void HandleJump()
        {
            // Used https://gamedevbeginner.com/how-to-jump-in-unity-with-or-without-physics/ for jumping mechanic
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        private void Jump()
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
            if (_rigidbody.position.x >= stoppingPoint && _groundChecker.GetIsTouchingGround())
            {
                Vector3 velocity = _rigidbody.velocity;
                velocity = new Vector3(-((_rigidbody.position.x - stoppingPoint) / returnToStoppingPointTime + playerSpeed), velocity.y, velocity.z);
                _rigidbody.velocity = velocity;
            }
            else
            {
                Vector3 velocity = _rigidbody.velocity;
                velocity = new Vector3(playerSpeed, velocity.y, velocity.z);
                _rigidbody.velocity = velocity;
            }
        }
    }
}
