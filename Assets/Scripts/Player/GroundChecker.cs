using UnityEngine;

namespace Player
{
    public class GroundChecker : MonoBehaviour
    {
        private bool _isTouchingGround = false;
        public bool GetIsTouchingGround()
        {
            return _isTouchingGround;
        }

        private GameObject _collidedWith;
        public GameObject GetCollidedWith()
        {
            return _collidedWith;
        }

        // Without a rigidbody attached to Ground_Checker these functions will not work
        private void OnCollisionEnter(Collision other)
        {
            _isTouchingGround = true;
            _collidedWith = other.gameObject;
        }

        private void OnCollisionExit()
        {
            _isTouchingGround = false;
        }
    }
}
