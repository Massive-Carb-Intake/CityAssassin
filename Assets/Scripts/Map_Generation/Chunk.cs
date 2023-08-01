using System;
using UnityEngine;

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

        void Update()
        {
            HandleDestruction();
        }
        

        private void HandleDestruction()
        {
            if (transform.position.x <= _chunkHandler.GetCameraLocationSimplified() -
                (_chunkHandler.GetChunksPreloaded() * 2 * _chunkHandler.GetChunkLength()))
            {
                Destroy(gameObject);
            }
        }
    }
}
