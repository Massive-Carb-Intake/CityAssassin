using UnityEngine;

namespace Map_Generation
{
    public class ChunkMover : MonoBehaviour
    {
        [SerializeField] private float speed = 1f; // TODO change to global speed variable
        
        // Update is called once per frame
        void Update()
        {
            Move();
        }

        private void Move()
        {
            // Moves the chunk without using the physics engine by one meter times the speed
            transform.position += (new Vector3(-1, 0, 0) * (speed * Time.deltaTime));
        }
    }
}
