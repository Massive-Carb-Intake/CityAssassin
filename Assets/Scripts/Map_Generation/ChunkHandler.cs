using System.Collections.Generic;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Map_Generation
{
    public class ChunkHandler : MonoBehaviour
    {
        // Spawn locations
        [SerializeField] private Vector3 chunkSpawnLocation = new Vector3(30, 0, 0);
        [SerializeField] private Vector3 chunkDespawnLocation = new Vector3(30, 0, 0);
        public Vector3 GetChunkDespawnLocation()
        {
            return chunkDespawnLocation;
        }
        
        // Chunk parameters
        [SerializeField] private float chunkLength = 10f;
        public float GetChunkLength()
        {
            return chunkLength;
        }
        private float _timePassed;
        private float _spawnInterval;
        public float GetSpawnInterval()
        {
            return _spawnInterval;
        }
        
        // Chunk prefabs
        [SerializeField] private List<GameObject> chunks;
        
        private GameMode _gameMode;

        // Start is called before the first frame update
        void Start()
        {
            // Used https://www.youtube.com/watch?v=Y7pp2gzCzUI to figure out how to reference other components
            _gameMode = GameObject.Find("Player").GetComponent<GameMode>();
            GenerateChunk();
            // Self-initialization but it has to happen after a chunk is generated
            _timePassed = 0;
        }

        private void UpdateSpawnInterval()
        {
            _spawnInterval = chunkLength / _gameMode.GetWorldSpeed();
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
            // Grabs the new speed only after one interval has passed because otherwise it will generate chunks wrong
            UpdateSpawnInterval();
            Instantiate(chunks[Random.Range(0, chunks.Count)], chunkSpawnLocation, Quaternion.identity);
        }
    }
}
