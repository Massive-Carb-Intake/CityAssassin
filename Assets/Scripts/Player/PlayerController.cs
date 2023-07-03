using System;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float worldSpeed = 1f;
        public float GetWorldSpeed()
        {
            return worldSpeed;
        }
        
        [SerializeField] private float playerSpeed = 10f;
        [SerializeField] private float jumpMultiplier = 22f;
        [SerializeField] private float gravityScale = 5f;
        [SerializeField] private float stoppingPoint = 10f;

        private Rigidbody _rigidbody;
        private GroundChecker _groundChecker;

        // All self-initializations (stuff that doesn't rely on other components) should happen in Awake()
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        // Start is called before the first frame update
        void Start()
        {
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
            if (!(_rigidbody.position.x > stoppingPoint))
            {
                _rigidbody.AddForce(Vector3.right * (playerSpeed * Time.deltaTime));
            }
            ClampPosition();
        }

        private void HandleJump()
        {
            // Used https://gamedevbeginner.com/how-to-jump-in-unity-with-or-without-physics/ for jumping mechanic
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (CanJump())
                {
                    _rigidbody.AddForce(Vector3.up * jumpMultiplier, ForceMode.Impulse);
                }
            }
        }

        private bool CanJump()
        {
            return _groundChecker.GetIsTouchingGround();
        }

        private void ClampPosition()
        {
            if (_rigidbody.position.x >= stoppingPoint)
            {
                _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, _rigidbody.velocity.z);
                _rigidbody.position = new Vector3(stoppingPoint, _rigidbody.position.y, _rigidbody.position.z);
            }
        }
    }
}
