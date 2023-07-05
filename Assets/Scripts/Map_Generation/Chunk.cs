using System;
using UnityEngine;

namespace Map_Generation
{
    public class Chunk : MonoBehaviour
    {
        // Stores a reference to the ChunkHandler located on Chunk_Handler in the world
        private ChunkHandler _chunkHandler;
        private Rigidbody _rigidbody;

        /*
         As of right now worldSpeed can't be set crazy high because there are no rigidbodies attached
        attached to the chunks. This means that the player can phase through the floor at higher speeds
        due to a lack of continuous collision checking. However, as of right now, idek if we'll ever reach
        those speeds so i won't deal with the headache of attaching rigidbodies and dealing with them
        sliding after colliding into one another.
        
        Also if we're using rigidbodies we have to deal with friction:
        https://forum.unity.com/threads/what-is-the-default-friction-values-of-the-none-physics-2d-materiel.382109/
        
        This serves as a way into figuring it out later.
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        */

        private void Start()
        {
            _chunkHandler = GameObject.Find("Chunk_Handler").GetComponent<ChunkHandler>();
        }

        void Update()
        {
            Move();
            HandleDestruction();
        }
        

        private void HandleDestruction()
        {
            if (transform.position.x <= _chunkHandler.GetChunkDespawnLocation().x)
            {
                Destroy(gameObject);
            }
        }

        private void Move()
        {
            // Moves the chunk without using the physics engine by one meter times the worldSpeed the chunks are being generated at rather than the current worldSpeed.
            transform.position += (new Vector3(-1, 0, 0) * ( _chunkHandler.GetChunkLength() / _chunkHandler.GetSpawnInterval() * Time.deltaTime));
        }
    }
}
