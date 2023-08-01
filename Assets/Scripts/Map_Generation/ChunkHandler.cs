using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Map_Generation
{
    public class ChunkHandler : MonoBehaviour
    {
        [SerializeField] private int chunksPreloaded = 3;
        public int GetChunksPreloaded()
        {
            return chunksPreloaded;
        }

        // Chunk parameters
        [SerializeField] private float chunkLength = 10f;
        public float GetChunkLength()
        {
            return chunkLength;
        }
        
        // Chunk prefabs
        [SerializeField] private List<GameObject> chunks;

        private float _cameraLocationSimplified = 0;
        public float GetCameraLocationSimplified()
        {
            return _cameraLocationSimplified;
        }

        // Update is called once per frame
        void Update()
        {
            HandleGeneration();
        }

        private void HandleGeneration()
        {
            if (!(transform.position.x >= GetCameraLocationSimplified())) return;
            GenerateChunk();
            _cameraLocationSimplified += GetChunkLength();
        }

        private void GenerateChunk()
        {
            Instantiate(chunks[Random.Range(0, chunks.Count)], new Vector3((GetCameraLocationSimplified() +
                                                                            (GetChunkLength() *
                                                                             GetChunksPreloaded())), 0, 0), Quaternion.identity);
        }
    }
}
