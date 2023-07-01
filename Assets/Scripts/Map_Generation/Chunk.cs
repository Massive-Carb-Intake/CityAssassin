using System;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Map_Generation
{
    public class Chunk : MonoBehaviour
    {
        // Stores a reference to the ChunkHandler located on Chunk_Handler in the world
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
