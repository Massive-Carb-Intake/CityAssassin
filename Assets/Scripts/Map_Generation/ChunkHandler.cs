using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Map_Generation
{
    public class ChunkHandler : MonoBehaviour
    {
        // Spawn locations
        [SerializeField] private Vector3 chunkSpawnLocation = new Vector3(30, 0, 0);
        public Vector3 chunkDespawnLocation;
        
        // Chunk parameters
        [SerializeField] private float chunkLength = 10f;
        [SerializeField] private float speed = 1f; // TODO change to global speed variable
        private float _spawnInterval;
        private float _timePassed;
        
        // Chunk prefabs
        [SerializeField] private List<GameObject> chunks;
        
        // Sets the despawn location
        // All self-initializations (stuff that doesn't rely on other components) should happen in Awake()
        private void Awake()
        {
            chunkDespawnLocation = new Vector3(-chunkSpawnLocation.x, chunkSpawnLocation.y, chunkSpawnLocation.z);
        }

        // Start is called before the first frame update
        void Start()
        {
            _spawnInterval = chunkLength / speed;
            
            // Self-initialization but it has to happen after a chunk is generated
            GenerateChunk();
            _timePassed = 0;
        }

        // Update is called once per frame
        void Update()
        {
            // Spawns a chunk as soon as time passed is equal to the interval
            // Used https://discussions.unity.com/t/simple-timer/56201/2 to figure out a timer system
            if (_timePassed >= _spawnInterval)
            {
                GenerateChunk();
                _timePassed = 0;
            }
            _timePassed += Time.deltaTime;
        }

        private void GenerateChunk()
        {
            Instantiate(chunks[Random.Range(0, chunks.Count)], chunkSpawnLocation, Quaternion.identity);
        }
    }
}
