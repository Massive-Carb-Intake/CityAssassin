using UnityEngine;

namespace Player
{
    public class GroundChecker : MonoBehaviour
    {
        private bool _isTouchingGround;

        public bool GetIsTouchingGround()
        {
            return _isTouchingGround;
        }

        // Without a rigidbody attached to Ground_Checker these functions will not work
        private void OnCollisionEnter()
        {
            _isTouchingGround = true;
            Debug.Log(_isTouchingGround);
        }

        private void OnCollisionExit()
        {
            _isTouchingGround = false;
        }
    }
}
