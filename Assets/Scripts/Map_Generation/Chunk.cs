using System;
using UnityEngine;

namespace Map_Generation
{
    public class Chunk : MonoBehaviour
    {
        [SerializeField] private float speed = 1f; // TODO change to global speed variable
        
        // Stores a reference to the ChunkHandler located on Chunk Spawner in the world
        private ChunkHandler _chunkHandler; 

        private void Start()
        {
            _chunkHandler = GameObject.Find("Chunk_Handler").GetComponent<ChunkHandler>();
        }

        // Update is called once per frame
        void Update()
        {
            Move();
            HandleDestruction();
        }

        private void HandleDestruction()
        {
            if (transform.position.x <= _chunkHandler.chunkDespawnLocation.x)
            {
                Destroy(gameObject);
            }
        }

        private void Move()
        {
            // Moves the chunk without using the physics engine by one meter times the speed
            transform.position += (new Vector3(-1, 0, 0) * (speed * Time.deltaTime));
        }
    }
}
