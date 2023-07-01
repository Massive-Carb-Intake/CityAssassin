using UnityEngine;

namespace Player
{
    public class GroundChecker : MonoBehaviour
    {
        public bool isTouchingGround = false;
        
        // Without a rigidbody attached to Ground_Checker these functions will not work
        private void OnCollisionEnter(Collision other)
        {
            isTouchingGround = true;
            Debug.Log(isTouchingGround);
        }

        private void OnCollisionExit(Collision other)
        {
            isTouchingGround = false;
        }
    }
}
